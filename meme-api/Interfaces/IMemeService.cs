using meme_api.Models;
using meme_api.Entity;

namespace meme_api.Interfaces
{
    public interface IMemeService
    {
        Task<IEnumerable<Meme>> GetAll();
        Task<IEnumerable<Meme>> GetMemesByUserId(Guid userId);
        Task<Meme?> GetMemeByUserId(Guid userId, Guid memeId);
        Task<Meme?> AddMeme(MemeDTO meme);
        Task<Meme?> UpdateMeme(MemeDTO meme);
        Task<bool> DeleteMemeById(Guid memeId);
    }
}
