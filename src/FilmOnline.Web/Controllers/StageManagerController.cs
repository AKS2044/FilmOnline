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
    public class StageManagerController : Controller
    {
        private readonly IStageManagerService _stageManagerService;
        private readonly IFilmService _filmService;
        private readonly IGenreService _genreService;

        /// <summary>
        /// Constructor with params.
        /// </summary>
        /// <param name="filmService">Film Service.</param>
        /// <param name="stageManagerService">Stage manager Service.</param>
        /// <param name="genreService">Genre Service.</param>
        public StageManagerController(IStageManagerService stageManagerService, IFilmService filmService, IGenreService genreService)
        {
            _stageManagerService = stageManagerService ?? throw new ArgumentNullException(nameof(stageManagerService));
            _filmService = filmService ?? throw new ArgumentNullException(nameof(filmService));
            _genreService = genreService ?? throw new ArgumentNullException(nameof(filmService));
        }

        /// <summary>
        /// Add stage manager view.
        /// </summary>
        public async Task<IActionResult> Index()
        {
            var token = User.FindFirst(ClaimTypes.CookiePath).Value;

            var filmCollection = await _filmService.GetAllShortAsync();
            var genreCollection = await _genreService.GetAllGenreAsync();
            var resultRandomFilm = await _filmService.GetRandomFilmByIdAsync();
            var stageManagerCollection = await _stageManagerService.GetAllStageManagerAsync();

            ViewBag.RandomFilm = resultRandomFilm.Id;
            ViewBag.Genres = genreCollection;
            ViewBag.Films = filmCollection.Take(7);

            StageManagerViewModel result = new()
            {
                StageManagerModelResponses = stageManagerCollection
            };

            return View(result);
        }

        /// <summary>
        /// Add stage manager(Post).
        /// <param name="request">Stage manager request.</param>
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> AddStageManager(StageManagerViewModel request)
        {
            if (request.StageManager is null)
            {
                return NoContent();
            }

            var token = User.FindFirst(ClaimTypes.CookiePath).Value;
            await _stageManagerService.AddStageManagerAsync(request.StageManager, token);

            return RedirectToAction("Index", "StageManager");
        }

        /// <summary>
        /// Upgrade stage manager (Post).
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> UpgradeStageManager(int id, StageManagerViewModel request)
        {
            if (request.StageManager is null)
            {
                return NoContent();
            }
            var token = User.FindFirst(ClaimTypes.CookiePath).Value;
            await _stageManagerService.UpgradeStageManagerAsync(id, token, request.StageManager);
            return RedirectToAction("Index", "StageManager");
        }

        /// <summary>
        /// Delete stage manager (Post).
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> DeleteStageManager(int id)
        {
            var token = User.FindFirst(ClaimTypes.CookiePath).Value;
            await _stageManagerService.DeleteStageManagerAsync(id, token);
            return RedirectToAction("Index", "StageManager");
        }
    }
}
