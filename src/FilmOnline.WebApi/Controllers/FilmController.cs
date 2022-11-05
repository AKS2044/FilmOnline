using FilmOnline.Data.Models;
using FilmOnline.Logic.Interfaces;
using FilmOnline.Logic.Models;
using FilmOnline.Web.Shared.Models;
using FilmOnline.Web.Shared.Models.Request;
using FilmOnline.Web.Shared.Models.Responses;
using FilmOnline.WebApi.Attributes;
using FilmOnline.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        private readonly UserManager<User> _userManager;

        public FilmController(IFilmManager filmManager, 
                              IWebHostEnvironment appEnvironment, 
                              UserManager<User> userManager)
        {
            _filmManager = filmManager ?? throw new ArgumentNullException(nameof(filmManager));
            _appEnvironment = appEnvironment ?? throw new ArgumentNullException(nameof(appEnvironment));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        [OwnAuthorize]
        [HttpPost("addfilm")]
        public async Task<IActionResult> CreateAsync([FromBody] FilmCreateRequest request/*, IFormFile uploadedFile*/)
        {
            var filmActorDtos = new List<FilmActorDto>();
            var filmGenreDtos = new List<FilmGenreDto>();
            var filmCountryDtos = new List<FilmCountryDto>();
            var filmStageManagerDtos = new List<FilmStageManagerDto>();

            //string path = "/Files/" + uploadedFile.FileName;
            //using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
            //{
            //    await uploadedFile.CopyToAsync(fileStream);
            //}

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
                RatingSite = request.RatingSite,
                LinkFilmtrailer = request.LinkFilmtrailer,
                LinkFilmPlayer = request.LinkFilmPlayer
            };

            if (request.IdRating != 0)
            {
                var idRating = request.IdRating;
                Uri baseURI = new("https://rating.kinopoisk.ru/");
                Uri XmlPuth = new(baseURI, $"{idRating}.xml");
                string xmlStr;
                WebClient webClient = new();
                using (WebClient wc = webClient)
                {
                    xmlStr = wc.DownloadString(XmlPuth);
                }
                var xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xmlStr);

                XmlNodeList saveItems = xmlDoc.SelectNodes("rating");
                XmlNode kinopoisk = saveItems.Item(0).SelectSingleNode("kp_rating");
                XmlNode imdb = saveItems.Item(0).SelectSingleNode("imdb_rating");
                string kinopoiskData = kinopoisk.InnerText;
                if (imdb is not null)
                {
                    string ImdbData = imdb.InnerText;
                    filmDto.RatingImdb = ImdbData;
                }
                filmDto.RatingKinopoisk = kinopoiskData;
            }

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

        [HttpGet("")]
        public async Task<IActionResult> Get(int id)
        {
            var film = await _filmManager.GetByIdAsync(id);

            return Ok(film);
        }

        [OwnAuthorize]
        [HttpPost("UpgradeFilm")]
        public async Task<IActionResult> UpgradeFilmAsync([FromBody] FilmUpgradeModel request)
        {
            var filmActorDtos = new List<FilmActorDto>();
            var filmGenreDtos = new List<FilmGenreDto>();
            var filmCountryDtos = new List<FilmCountryDto>();
            var filmStageManagerDtos = new List<FilmStageManagerDto>();

            FilmDto filmDto = new()
            {
                Id = request.Id,
                ImageName = request.ImageName,
                PathPoster = request.PathPoster,
                NameFilms = request.NameFilms,
                AgeLimit = request.AgeLimit,
                ReleaseDate = request.ReleaseDate,
                Time = request.Time,
                Description = request.Description,
                IdRating = request.IdRating,
                RatingSite = request.RatingSite,
                LinkFilmtrailer = request.LinkFilmtrailer,
                LinkFilmPlayer = request.LinkFilmPlayer
            };

            if (request.IdRating != 0)
            {
                var idRating = request.IdRating;
                Uri baseURI = new("https://rating.kinopoisk.ru/");
                Uri XmlPuth = new(baseURI, $"{idRating}.xml");
                string xmlStr;
                WebClient webClient = new();
                using (WebClient wc = webClient)
                {
                    xmlStr = wc.DownloadString(XmlPuth);
                }
                var xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xmlStr);

                XmlNodeList saveItems = xmlDoc.SelectNodes("rating");
                XmlNode kinopoisk = saveItems.Item(0).SelectSingleNode("kp_rating");
                XmlNode imdb = saveItems.Item(0).SelectSingleNode("imdb_rating");
                string kinopoiskData = kinopoisk.InnerText;
                if (imdb is not null)
                {
                    string ImdbData = imdb.InnerText;
                    filmDto.RatingImdb = ImdbData;
                }
                filmDto.RatingKinopoisk = kinopoiskData;
            }

            if (request.ActorIds is not null)
            {
                foreach (var item in request.ActorIds)
                {
                    filmActorDtos.Add(new FilmActorDto
                    {
                        ActorId = item
                    });
                }
            }

            if (request.GenreIds is not null)
            {
                foreach (var item in request.GenreIds)
                {
                    filmGenreDtos.Add(new FilmGenreDto
                    {
                        GenreId = item
                    });
                }
            }

            if (request.CountryIds is not null)
            {
                foreach (var item in request.CountryIds)
                {
                    filmCountryDtos.Add(new FilmCountryDto
                    {
                        FilmId = request.Id,
                        CountryId = item
                    });
                }
            }

            if (request.StageManagerIds is not null)
            {
                foreach (var item in request.StageManagerIds)
                {
                    filmStageManagerDtos.Add(new FilmStageManagerDto
                    {
                        StageManagerId = item
                    });
                }
            }

            if (ModelState.IsValid)
            {
                await _filmManager.UpgradeFilmAsync(filmDto,
                    filmActorDtos,
                    filmGenreDtos,
                    filmCountryDtos,
                    filmStageManagerDtos);
            }

            return Ok();
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
        public async Task<IActionResult> GetAllFilmsByGenre([FromBody] int genre)
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

        [HttpGet("Films")]
        public async Task<IActionResult> GetAll([FromQuery] QueryParameters parametrs)
        {

            var film = await _filmManager.GetAllAsync(parametrs.Page);


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

        [OwnAuthorize]
        [HttpDelete("DeleteFilm{id}")]
        public async Task DeleteAsync(int id)
        {
            await _filmManager.DeleteAsync(id);
        }

        [HttpPost("AddFavouriteFilm")]
        public async Task<IActionResult> AddFavouriteFilmAsync(UserFilmRequest request)
        {
            var idUser = await _userManager.FindByNameAsync(request.UserName);
            await _filmManager.AddFavouriteFilmAsync(request.FilmId, idUser.Id);
            return Ok();
        }

        [HttpDelete("DeleteFavouriteFilm")]
        public async Task<IActionResult> DeleteFavouriteFilmAsync(UserFilmRequest request)
        {
            var idUser = await _userManager.FindByNameAsync(request.UserName);
            await _filmManager.DeleteFavouriteFilmAsync(request.FilmId, idUser.Id);
            return Ok();
        }

        [HttpGet("GetAllFavouriteFilm")]
        public async Task<IActionResult> GetAllFavouriteFilmAsync([FromBody] string userName)
        {
            var idUser = await _userManager.FindByNameAsync(userName);
            var model = await _filmManager.GetAllFavouriteFilmAsync(idUser.Id);
            var result = new List<FilmShortModelResponse>();
            foreach (var item in model)
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

        [HttpPost("AddWatchLaterFilm")]
        public async Task<IActionResult> AddWatchLaterFilmAsync(UserFilmRequest request)
        {
            var idUser = await _userManager.FindByNameAsync(request.UserName);
            await _filmManager.AddWatchLaterFilmAsync(request.FilmId, idUser.Id);
            return Ok();
        }

        [HttpDelete("DeleteWatchLaterFilm")]
        public async Task<IActionResult> DeleteWatchLaterFilmAsync(UserFilmRequest request)
        {
            var idUser = await _userManager.FindByNameAsync(request.UserName);
            await _filmManager.DeleteWatchLaterFilmAsync(request.FilmId, idUser.Id);
            return Ok();
        }

        [HttpGet("GetAllWatchLaterFilm")]
        public async Task<IActionResult> GetAlWatchLaterFilmAsync([FromBody] string userName)
        {
            var idUser = await _userManager.FindByNameAsync(userName);
            var model = await _filmManager.GetAllWatchLaterFilmAsync(idUser.Id);
            var result = new List<FilmShortModelResponse>();
            foreach (var item in model)
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
    }
}
