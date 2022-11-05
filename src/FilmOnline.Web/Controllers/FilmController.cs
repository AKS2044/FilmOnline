﻿using FilmOnline.Web.Interfaces;
using FilmOnline.Web.ViewModels;
using FilmOnline.Web.Shared.Models.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FilmOnline.Web.Shared.Models;

namespace FilmOnline.Web.Controllers
{
    /// <summary>
    /// Film controller.
    /// </summary>
    public class FilmController : Controller
    {
        public readonly IWebHostEnvironment _appEnvironment;
        private readonly IFilmService _filmService;
        private readonly ICountryService _countryService;
        private readonly IActorService _actorService;
        private readonly IGenreService _genreService;

        /// <summary>
        /// Constructor with params.
        /// </summary>
        /// <param name="filmService">Film Service.</param>
        /// <param name="actorService">Actor Service.</param>
        /// <param name="countryService">Country Service.</param>
        /// <param name="appEnvironment">App Environment.</param>
        public FilmController(IWebHostEnvironment appEnvironment, 
                              IFilmService filmService,
                              ICountryService countryService,
                              IActorService actorService,
                              IGenreService genreService)
        {
            _appEnvironment = appEnvironment ?? throw new ArgumentNullException(nameof(appEnvironment));
            _filmService = filmService ?? throw new ArgumentNullException(nameof(filmService));
            _countryService = countryService ?? throw new ArgumentNullException(nameof(countryService));
            _actorService = actorService ?? throw new ArgumentNullException(nameof(actorService));
            _genreService = genreService ?? throw new ArgumentNullException(nameof(genreService));
        }

        /// <summary>
        /// Index film view (Get).
        /// </summary>
        /// <param name="id">Id film.</param>
        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            var resultRandomFilm = await _filmService.GetRandomFilmByIdAsync();
            var filmCollection = await _filmService.GetAllShortAsync();
            var genreCollection = await _genreService.GetAllGenreAsync();
            ViewBag.Genres = genreCollection;
            ViewBag.Films = filmCollection.Take(7);
            ViewBag.RandomFilm = resultRandomFilm.Id;
            ViewBag.Recommended = filmCollection.Take(6);

            var result = await _filmService.GetByIdAsync(id);
            return View(result);
        }

        /// <summary>
        /// Add film view(Get).
        /// </summary>
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> AddFilms()
        {
            var token = User.FindFirst(ClaimTypes.CookiePath).Value;

            var filmCollection = await _filmService.GetAllShortAsync();
            var genreCollection = await _genreService.GetAllGenreAsync();
            var countryCollection = await _countryService.GetAllCountryAsync();
            var actorsCollection = await _actorService.GetAllActorAsync();
            var stageManagersCollection = await _filmService.GetAllStageManagerAsync();
            var resultRandomFilm = await _filmService.GetRandomFilmByIdAsync();

            ViewBag.RandomFilm = resultRandomFilm.Id;
            ViewBag.AddGenres = new SelectList(genreCollection, "Id", "Genres");
            ViewBag.AddCountry = new SelectList(countryCollection, "Id", "Country");
            ViewBag.AddManager = new SelectList(stageManagersCollection, "Id", "StageManagers");
            ViewBag.AddActor = actorsCollection;
            ViewBag.Genres = genreCollection;
            ViewBag.Films = filmCollection.Take(7);
            return View();
        }

        /// <summary>
        /// Add film(Post).
        /// </summary>
        /// <param name="model">Film Create Request.</param>
        /// <param name="uploadedFile">Uploaded File.</param>
        [HttpPost]
        public async Task<IActionResult> AddFilms(FilmCreateRequest model, IFormFile uploadedFile)
        {
            model = model ?? throw new ArgumentNullException(nameof(model));
            var token = User.FindFirst(ClaimTypes.Name).Value;
            string path = "/Files/" + uploadedFile.FileName;
            using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
            {
                await uploadedFile.CopyToAsync(fileStream);
            }

            var request = new FilmCreateRequest
            {
                ImageName = uploadedFile.FileName,
                PathPoster = path,
                NameFilms = model.NameFilms,
                AgeLimit = model.AgeLimit,
                Time = model.Time,
                ReleaseDate = model.ReleaseDate,
                Description = model.Description,
                LinkFilmtrailer = model.LinkFilmtrailer,
                IdRating = model.IdRating,
                RatingSite = model.RatingSite,
                CountryIds = model.CountryIds,
                ActorIds = model.ActorIds,
                StageManagerIds = model.StageManagerIds,
                GenreIds = model.GenreIds
            };

            await _filmService.AddAsync(request, token);
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Get film by genre(Get).
        /// </summary>
        /// <param name="id">Film id.</param>
        [HttpGet]
        public async Task<IActionResult> Genre(int id)
        {
            var result = await _filmService.GetFilmByGenreIdAsync(id);
            var filmCollection = await _filmService.GetAllShortAsync();
            var genreCollection = await _genreService.GetAllGenreAsync();
            var resultRandomFilm = await _filmService.GetRandomFilmByIdAsync();

            foreach (var item in genreCollection)
            {
                if (item.Id == id)
                {
                    ViewBag.Genre = item.Genres;
                }
            }
            ViewBag.RandomFilm = resultRandomFilm.Id;
            ViewBag.Genres = genreCollection;
            ViewBag.Films = filmCollection;
            return View(result);
        }

        /// <summary>
        /// Upgrade film(Get).
        /// <param name="id">Id film.</param>
        /// </summary>
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Upgrade(int id)
        {
            var filmCollection = await _filmService.GetAllShortAsync();
            var genreCollection = await _genreService.GetAllGenreAsync();
            var countryCollection = await _countryService.GetAllCountryAsync();
            var actorsCollection = await _actorService.GetAllActorAsync();
            var stageManagersCollection = await _filmService.GetAllStageManagerAsync();
            var resultRandomFilm = await _filmService.GetRandomFilmByIdAsync();

            ViewBag.RandomFilm = resultRandomFilm.Id;
            ViewBag.AddGenres = new SelectList(genreCollection, "Id", "Genres");
            ViewBag.AddCountry = new SelectList(countryCollection, "Id", "Country");
            ViewBag.AddManager = new SelectList(stageManagersCollection, "Id", "StageManagers");
            ViewBag.AddActor = actorsCollection;
            ViewBag.Genres = genreCollection;
            ViewBag.Films = filmCollection.Take(7);

            var result = await _filmService.GetByIdAsync(id);

            return View(result);
        }

        /// <summary>
        /// Upgrade film(Post).
        /// <param name="id">Id film.</param>
        /// </summary>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> UpgradePost(FilmUpgradeModel model, int id, IFormFile uploadedFile) //Доделать загрузку постера и удаление старого при загрзке нового
        {
            model = model ?? throw new ArgumentNullException(nameof(model));
            var token = User.FindFirst(ClaimTypes.CookiePath).Value;
            if (uploadedFile is not null)
            {
                string path = "/Files/" + uploadedFile.FileName;
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }
                model.PathPoster = path;
                model.ImageName = uploadedFile.FileName;
            }

            var request = new FilmCreateRequest
            {
                Id = id,
                NameFilms = model.NameFilms,
                AgeLimit = model.AgeLimit,
                Time = model.Time,
                ReleaseDate = model.ReleaseDate,
                Description = model.Description,
                LinkFilmtrailer = model.LinkFilmtrailer,
                IdRating = model.IdRating,
                RatingSite = model.RatingSite,
                CountryIds = model.CountryIds,
                ActorIds = model.ActorIds,
                StageManagerIds = model.StageManagerIds,
                GenreIds = model.GenreIds
            };

            await _filmService.UpgradeFilmAsync(request, token);

            return RedirectToAction("Index", "Home");
        }
    }
}