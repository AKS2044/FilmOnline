﻿using FilmOnline.Web.Interfaces;
using FilmOnline.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FilmOnline.Web.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class CountryController : Controller
    {
        private readonly ICountryService _countryService;
        private readonly IFilmService _filmService;

        /// <summary>
        /// Constructor with params.
        /// </summary>
        /// <param name="filmService">Film Service.</param>
        /// <param name="countryService">Film Service.</param>
        public CountryController(ICountryService countryService, IFilmService filmService)
        {
            _countryService = countryService ?? throw new ArgumentNullException(nameof(countryService));
            _filmService = filmService ?? throw new ArgumentNullException(nameof(filmService));
        }

        /// <summary>
        /// Add country view.
        /// </summary>
        public async Task<IActionResult> Index()
        {
            var token = User.FindFirst(ClaimTypes.CookiePath).Value;

            var filmCollection = await _filmService.GetAllShortAsync();
            var genreCollection = await _filmService.GetAllGenreAsync();
            var resultRandomFilm = await _filmService.GetRandomFilmByIdAsync();
            var countryCollection = await _countryService.GetAllCountryAsync(token);

            ViewBag.RandomFilm = resultRandomFilm.Id;
            ViewBag.Genres = genreCollection;
            ViewBag.Films = filmCollection.Take(7);
            ViewBag.AllCountry = countryCollection;

            CountryViewModel result = new()
            {
                CountryModelResponses = countryCollection,
            };

            return View(result);
        }

        /// <summary>
        /// Add country(Post).
        /// <param name="request">Country request.</param>
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> AddCount(CountryViewModel request)
        {
            request = request ?? throw new ArgumentNullException(nameof(request));

            var token = User.FindFirst(ClaimTypes.CookiePath).Value;
            await _countryService.AddCountryAsync(request.Country, token);

            return RedirectToAction("Index", "Country");
        }

        /// <summary>
        /// Upgrade country (Post).
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> UpgradeCountry(int id, CountryViewModel request)
        {
            var token = User.FindFirst(ClaimTypes.CookiePath).Value;
            await _countryService.UpgradeCountryAsync(id, token, request.Country);
            return RedirectToAction("Index", "Country");
        }

        /// <summary>
        /// Delete country (Post).
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var token = User.FindFirst(ClaimTypes.CookiePath).Value;
            await _countryService.DeleteCountryAsync(id, token);
            return RedirectToAction("Index", "Country");
        }
    }
}
