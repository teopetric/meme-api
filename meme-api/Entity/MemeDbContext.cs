using Microsoft.EntityFrameworkCore;

namespace meme_api.Entity
{
    public class MemeDbContext : DbContext
    {
        public MemeDbContext(DbContextOptions<MemeDbContext> options) : base(options) { }

        public DbSet<User> User { get; set; }
        public DbSet<Meme> Meme { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(x => x.UserId).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<User>().HasKey(x => x.UserId);

            modelBuilder.Entity<Meme>().Property(x => x.MemeId).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Meme>().HasKey(x => x.MemeId);
            modelBuilder.Entity<Meme>().HasOne(x => x.User).WithMany(x => x.Memes).HasForeignKey(x => x.UserId).IsRequired();
        }
    }
}
