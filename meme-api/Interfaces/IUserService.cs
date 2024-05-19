using meme_api.Entity;

namespace meme_api.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAll();
        Task<User?> GetByEmail(string email);
        string GetToken(User user);
    }
}
