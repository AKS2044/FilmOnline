using FilmOnline.Logic.Interfaces;
using FilmOnline.Logic.Models;
using FilmOnline.Web.Shared.Models.Request;
using FilmOnline.WebApi.Attributes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FilmOnline.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreManager _genreManager;

        public GenreController(IGenreManager genreManager)
        {
            _genreManager = genreManager ?? throw new ArgumentNullException(nameof(genreManager));
        }

        [OwnAuthorize]
        [HttpPost("add")]
        public async Task<IActionResult> CreateAsync([FromBody] GenreCreateRequest request)
        {
            GenreDto genreDto = new()
            {
                Genres = request.Genres
            };

            if (ModelState.IsValid)
            {
                await _genreManager.CreateAsync(genreDto);
            }

            return Ok();
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllGenre()
        {
            var genres = await _genreManager.GetAllAsync();

            return Ok(genres);
        }

        [OwnAuthorize]
        [HttpDelete("")]
        public async Task DeleteAsync(int id)
        {
            await _genreManager.DeleteAsync(id);
        }

        [OwnAuthorize]
        [HttpPut("")]
        public async Task UpdateGenreAsync(GenreDto genreDto, int id)
        {
            GenreDto result = new()
            {
                Id = id,
                Genres = genreDto.Genres
            };
            await _genreManager.UpdateAsync(result);
        }
    }
}