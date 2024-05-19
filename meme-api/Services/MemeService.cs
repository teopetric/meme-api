using meme_api.Entity;
using meme_api.Interfaces;
using meme_api.Models;
using Microsoft.EntityFrameworkCore;


namespace meme_api.Services
{
    public class MemeService : IMemeService
    {
        private readonly MemeDbContext _db;
        private readonly IConfiguration _configuration;

        public MemeService(IConfiguration configuration, MemeDbContext db)
        {
            _db = db;
            _configuration = configuration;
        }

        public async Task<Meme?> AddMeme(MemeDTO meme)
        {
            var newMeme = new Meme()
            {
                TopCaption = meme.TopCaption,
                BottomCaption = meme.BottomCaption,
                ImageId = meme.ImageId,
                UserId = meme.UserId
            };

            _db.Meme.Add(newMeme);
            var result = await _db.SaveChangesAsync();

            return result > 0 ? newMeme : null;
        }


        public async Task<Meme?> UpdateMeme(MemeDTO meme)
        {
            var oldMeme = await _db.Meme.FirstOrDefaultAsync(x => x.MemeId == meme.MemeId);

            if(oldMeme == null)
            {
                return null;
            }

            oldMeme.TopCaption = meme.TopCaption;
            oldMeme.BottomCaption = meme.BottomCaption;
            oldMeme.ImageId = meme.ImageId;

            var result = await _db.SaveChangesAsync();
            return result > 0 ? oldMeme : null;
        }


        public async Task<bool> DeleteMemeById(Guid memeId)
        {
            var meme = await _db.Meme.FirstOrDefaultAsync(x => x.MemeId == memeId);

            if (meme == null)
            {
                return false;
            }

            _db.Meme.Remove(meme);

            var result = await _db.SaveChangesAsync();
            return result > 0;
        }

        public async Task<Meme?> GetMemeByUserId(Guid userId, Guid memeId)
        {
            return await _db.Meme.Where(x => x.UserId == userId && x.MemeId == memeId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Meme>> GetMemesByUserId(Guid userId)
        {
            return await _db.Meme.Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task<IEnumerable<Meme>> GetAll()
        {
            return await _db.Meme.ToListAsync();
        }
    }
}