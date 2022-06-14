using FilmOnline.Web.Interfaces;
using FilmOnline.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FilmOnline.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class GenreController : Controller
    {
        private readonly IGenreService _genreService;
        private readonly IFilmService _filmService;

        /// <summary>
        /// Constructor with params.
        /// </summary>
        /// <param name="filmService">Film Service.</param>
        /// <param name="genreService">Genre Service.</param>
        public GenreController(IGenreService genreService, IFilmService filmService)
        {
            _genreService = genreService ?? throw new ArgumentNullException(nameof(genreService));
            _filmService = filmService ?? throw new ArgumentNullException(nameof(filmService));
        }

        /// <summary>
        /// Add genre view.
        /// </summary>
        public async Task<IActionResult> Index()
        {
            var filmCollection = await _filmService.GetAllShortAsync();
            var genreCollection = await _genreService.GetAllGenreAsync();
            var resultRandomFilm = await _filmService.GetRandomFilmByIdAsync();

            ViewBag.RandomFilm = resultRandomFilm.Id;
            ViewBag.Genres = genreCollection;
            ViewBag.Films = filmCollection.Take(7);
            ViewBag.AllCountry = genreCollection;

            GenreViewModel result = new()
            {
                GenreModelResponses = genreCollection
            };

            return View(result);
        }

        /// <summary>
        /// Add genre(Post).
        /// <param name="request">Genre request.</param>
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> AddGenre(GenreViewModel request)
        {
            if (request.Genre is null)
            {
                return NoContent();
            }
            var token = User.FindFirst(ClaimTypes.CookiePath).Value;
            await _genreService.AddGenreAsync(request.Genre, token);

            return RedirectToAction("Index", "Genre");
        }

        /// <summary>
        /// Upgrade Genre (Post).
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> UpgradeGenre(int id, GenreViewModel request)
        {
            if (request.Genre is null)
            {
                return NoContent();
            }
            var token = User.FindFirst(ClaimTypes.CookiePath).Value;
            await _genreService.UpgradeGenreAsync(id, token, request.Genre);
            return RedirectToAction("Index", "Genre");
        }

        /// <summary>
        /// Delete genre (Post).
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> DeleteGenre(int id)
        {
            var token = User.FindFirst(ClaimTypes.CookiePath).Value;
            await _genreService.DeleteGenreAsync(id, token);
            return RedirectToAction("Index", "Genre");
        }
    }
}
