using meme_api.Interfaces;
using meme_api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace meme_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MemeController : ControllerBase
    {
        private readonly IMemeService _memeService;
        public MemeController(IMemeService memeService)
        {
            _memeService = memeService;
        }

        [HttpGet]
        [Route("/getMemes")]
        [AllowAnonymous]
        public async Task<IActionResult> GetMemes()
        {
            var memes = await _memeService.GetAll();

            return Ok(memes);
        }

        [HttpGet]
        [Route("/getMemesForUserId")]
        [AllowAnonymous]
        public async Task<IActionResult> GetMemesForUserId([FromQuery] Guid userId)
        {
            var memes = await _memeService.GetMemesByUserId(userId);

            return Ok(memes);
        }

        [HttpGet]
        [Route("/getMemeById")]
        [AllowAnonymous]
        public async Task<IActionResult> GetMemeById([FromQuery] Guid memeId, [FromQuery] Guid userId)
        {
            var meme = await _memeService.GetMemeByUserId(userId, memeId);

            return Ok(meme);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateMeme([FromBody] MemeDTO meme)
        {
            var newMeme = await _memeService.AddMeme(meme);

            if(newMeme == null) { return BadRequest(); }

            return Ok(newMeme);
        }

        [HttpPut]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateMeme([FromBody] MemeDTO meme)
        {
            var updatedMeme = await _memeService.UpdateMeme(meme);

            if (updatedMeme == null) { return BadRequest(); }

            return Ok(updatedMeme);
        }

        [HttpDelete]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteMeme([FromBody] Guid memeId)
        {
            var result = await _memeService.DeleteMemeById(memeId);

            if (!result) { return NotFound(); }

            return Ok(result);
        }
    }
}
