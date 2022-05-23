using FilmOnline.Logic.Interfaces;
using FilmOnline.Logic.Models;
using FilmOnline.Web.Shared.Models.Request;
using FilmOnline.Web.Shared.Models.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Xml;

namespace FilmOnline.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private readonly IFilmManager _filmManager;
        public readonly IWebHostEnvironment _appEnvironment;

        public FilmController(IFilmManager filmManager, IWebHostEnvironment appEnvironment)
        {
            _filmManager = filmManager ?? throw new ArgumentNullException(nameof(filmManager));
            _appEnvironment = appEnvironment ?? throw new ArgumentNullException(nameof(appEnvironment));
        }

        // POST api/<FilmController>
        [HttpPost("addfilm")]
        public async Task<IActionResult> CreateAsync([FromBody] FilmCreateRequest request)
        {
            var filmActorDtos = new List<FilmActorDto>();
            var filmGenreDtos = new List<FilmGenreDto>();
            var filmCountryDtos = new List<FilmCountryDto>();
            var filmStageManagerDtos = new List<FilmStageManagerDto>();


            var idRating = request.IdRating;
            Uri baseURI = new("https://rating.kinopoisk.ru/");
            Uri XmlPuth = new(baseURI, $"{idRating}.xml");
            string xmlStr;
            using (WebClient wc = new())
            {
                xmlStr = wc.DownloadString(XmlPuth);
            }
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlStr);

            XmlNodeList saveItems = xmlDoc.SelectNodes("rating");
            XmlNode kinopoisk = saveItems.Item(0).SelectSingleNode("kp_rating");
            XmlNode imdb = saveItems.Item(0).SelectSingleNode("imdb_rating");
            string kinopoiskData = kinopoisk.InnerText;
            string ImdbData = imdb.InnerText;

            FilmDto filmDto = new()
            {
                ImageName = request.ImageName,
                PathPoster = request.PathPoster,
                NameFilms = request.NameFilms,
                AgeLimit = request.AgeLimit,
                ReleaseDate = request.ReleaseDate,
                Time = request.Time,
                Description = request.Description,
                IdRating = request.IdRating,
                RatingImdb = ImdbData,
                RatingKinopoisk = kinopoiskData,
                RatingSite = request.RatingSite,
                LinkFilmtrailer = request.LinkFilmtrailer,
                LinkFilmPlayer = request.LinkFilmPlayer
            };

            foreach (var item in request.ActorIds)
            {
                filmActorDtos.Add(new FilmActorDto
                {
                    ActorId = item
                });
            }

            foreach (var item in request.GenreIds)
            {
                filmGenreDtos.Add(new FilmGenreDto
                {
                    GenreId = item
                });
            }

            foreach (var item in request.CountryIds)
            {
                filmCountryDtos.Add(new FilmCountryDto
                {
                    CountryId = item
                });
            }

            foreach (var item in request.StageManagerIds)
            {
                filmStageManagerDtos.Add(new FilmStageManagerDto
                {
                    StageManagerId = item
                });
            }


            if (ModelState.IsValid)
            {
               await _filmManager.CreateAsync(filmDto, 
                   filmActorDtos, 
                   filmGenreDtos, 
                   filmCountryDtos, 
                   filmStageManagerDtos);
            }

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var film = await _filmManager.GetByIdAsync(id);

            return Ok(film);
        }

        [HttpGet("Upgrade{id}")]
        public async Task<IActionResult> UpgradeFilm(int id)
        {
            var film = await _filmManager.GetByIdForUpgradeAsync(id);

            return Ok(film);
        }

        [HttpGet("name")]
        public async Task<IActionResult> GetName([FromBody] string name)
        {
            var film = await _filmManager.GetByNameAsync(name);
            if (film is null)
            {
                return NotFound(film);
            }
            return Ok(film);
        }

        [HttpGet("genre")]
        public async Task<IActionResult> GetAllFilmsByGenre([FromBody] int genre) //Доделать вывод в mvc
        {
            var film = await _filmManager.GetFilmByGenreAsync(genre);
            var result = new List<FilmShortModelResponse>();
            foreach (var item in film)
            {
                result.Add(new FilmShortModelResponse
                {
                    Id = item.Id,
                    NameFilms = item.NameFilms,
                    ReleaseDate = item.ReleaseDate,
                    PathPoster = item.PathPoster
                });
            }
            return Ok(result);
        }

        [HttpGet("allFilms")]
        public async Task<IActionResult> GetAll()
        {
            var film = await _filmManager.GetAllShortAsync();

            return Ok(film);
        }

        [HttpGet("randomFilmId")]
        public async Task<IActionResult> GetRandomFilmId()
        {
            var filmId = await _filmManager.GetRandomFilmAsync();
            var film = await _filmManager.GetByIdAsync(filmId);

            return Ok(film);
        }

        [HttpPost("rating")]
        public async Task<IActionResult> AddRatingAsync(int filmId, int score)
        {
            await _filmManager.AddScoreFilmAsync(filmId, score);
            return Ok();
        }

        [HttpGet("Totalrating")]
        public async Task<IActionResult> TotalRatingAsync(int filmId)
        {
            var result = await _filmManager.GetTotalScoreFilm(filmId);
            return Ok(result);
        }

        // DELETE api/<FilmController>/5
        [HttpDelete("DeleteFilm{id}")]
        public async Task DeleteAsync(int id)
        {
            await _filmManager.DeleteAsync(id);
        }
    }
}
