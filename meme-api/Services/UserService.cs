using meme_api.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using meme_api.Entity;

namespace meme_api.Services
{
    public class UserService : IUserService
    {
        private readonly MemeDbContext _db;
        private readonly IConfiguration _configuration;

        public UserService(IConfiguration configuration, MemeDbContext db)
        {
            _db = db;
            _configuration = configuration;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _db.User.ToListAsync();
        }

        public async Task<User?> GetByEmail(string email)
        {
            return await _db.User.FirstOrDefaultAsync(x => x.Email == email);
        }

        public string GetToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim("userId", user.UserId.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            string userToken = tokenHandler.WriteToken(token);

            return userToken;
        }
    }
}
