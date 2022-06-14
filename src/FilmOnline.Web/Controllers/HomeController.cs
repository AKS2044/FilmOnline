using FilmOnline.Web.Interfaces;
using FilmOnline.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FilmOnline.Web.Controllers
{
    /// <summary>
    /// Home controller.
    /// </summary>
    public class HomeController : Controller
    {
        private readonly IFilmService _filmService;
        private readonly IGenreService _genreService;

        /// <summary>
        /// Constructor with params.
        /// </summary>
        /// <param name="filmService">Film Service.</param>
        /// /// <param name="genreService">Genre Service.</param>
        public HomeController(IFilmService filmService, IGenreService genreService)
        {
            _filmService = filmService ?? throw new ArgumentNullException(nameof(filmService));
            _genreService = genreService ?? throw new ArgumentNullException(nameof(filmService));
        }

        /// <summary>
        /// Index film (Get).
        /// </summary>
        /// <param name="page">Page number.</param>
        [HttpGet]
        public async Task<IActionResult> Index(int page = 1)
        {
            var result = await _filmService.GetAllShortAsync();
            int pageSize = 4;
            var count = result.Count();
            var items = result.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            PageViewModel pageViewModel = new(count, page, pageSize);
            IndexViewModel viewModel = new()
            {
                PageViewModel = pageViewModel,
                FilmShortModelResponses = items
            };

            var genreCollection = await _genreService.GetAllGenreAsync();
            var resultRandomFilm = await _filmService.GetRandomFilmByIdAsync();

            ViewBag.RandomFilm = resultRandomFilm.Id;
            ViewBag.Genres = genreCollection;
            ViewBag.Films = result.Take(7);
            return View(viewModel);
        }

        /// <summary>
        /// Search film (Get).
        /// </summary>
        /// <param name="name">Name search.</param>
        [HttpGet]
        public async Task<IActionResult> Search(string name)
        {
            var filmCollection = await _filmService.GetAllShortAsync();
            var genreCollection = await _genreService.GetAllGenreAsync();
            var resultRandomFilm = await _filmService.GetRandomFilmByIdAsync();

            ViewBag.RandomFilm = resultRandomFilm.Id;
            ViewBag.Genres = genreCollection;
            ViewBag.Films = filmCollection.Take(7);
            var result = await _filmService.GetByNameAsync(name);

            return View(result);
        }

        /// <summary>
        /// Admin panel (Get).
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Admin()
        {
            var filmCollection = await _filmService.GetAllShortAsync();
            var genreCollection = await _genreService.GetAllGenreAsync();
            var resultRandomFilm = await _filmService.GetRandomFilmByIdAsync();

            ViewBag.RandomFilm = resultRandomFilm.Id;
            ViewBag.Genres = genreCollection;
            ViewBag.Films = filmCollection.Take(7);

            return View(filmCollection);
        }

        /// <summary>
        /// Delete film (Post).
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var token = User.FindFirst(ClaimTypes.CookiePath).Value;
            await _filmService.DeleteFilmAsync(id, token);
            return RedirectToAction("Admin", "Home");
        }
    }
}