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
    public class ActorController : Controller
    {
        private readonly ICountryService _countryService;
        private readonly IFilmService _filmService;
        private readonly IGenreService _genreService;
        private readonly IActorService _actorService;

        /// <summary>
        /// Constructor with params.
        /// </summary>
        /// <param name="filmService">Film Service.</param>
        /// <param name="countryService">Country Service.</param>
        /// <param name="genreService">Genre Service.</param>
        /// <param name="actorService">Actor Service.</param>
        public ActorController(ICountryService countryService, 
                               IFilmService filmService, 
                               IGenreService genreService, 
                               IActorService actorService)
        {
            _countryService = countryService ?? throw new ArgumentNullException(nameof(countryService));
            _filmService = filmService ?? throw new ArgumentNullException(nameof(filmService));
            _genreService = genreService ?? throw new ArgumentNullException(nameof(filmService));
            _actorService = actorService ?? throw new ArgumentNullException(nameof(filmService));
        }

        /// <summary>
        /// Add actor view.
        /// </summary>
        public async Task<IActionResult> Index()
        {
            var filmCollection = await _filmService.GetAllShortAsync();
            var genreCollection = await _genreService.GetAllGenreAsync();
            var resultRandomFilm = await _filmService.GetRandomFilmByIdAsync();
            var actorCollection = await _actorService.GetAllActorAsync();

            ViewBag.RandomFilm = resultRandomFilm.Id;
            ViewBag.Genres = genreCollection;
            ViewBag.Films = filmCollection.Take(7);

            ActorViewModel result = new()
            {
                ActorModelResponses = actorCollection
            };

            return View(result);
        }

        /// <summary>
        /// Add actor(Post).
        /// <param name="request">Actor request.</param>
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> AddActor(ActorViewModel request)
        {
            if (request.ActorCreateRequest.FirstName is null &
                request.ActorCreateRequest.LastName is null &
                request.ActorCreateRequest.SecondName is null)
            {
                return NoContent();
            }

            var token = User.FindFirst(ClaimTypes.CookiePath).Value;
            await _actorService.AddActorAsync(request.ActorCreateRequest, token);

            return RedirectToAction("Index", "Actor");
        }

        /// <summary>
        /// Upgrade Actor (Post).
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> UpgradeActor(int id, ActorViewModel request)
        {
            if (request.ActorCreateRequest.FirstName is null & 
                request.ActorCreateRequest.LastName is null &
                request.ActorCreateRequest.SecondName is null)
            {
                return NoContent();
            }
            var token = User.FindFirst(ClaimTypes.CookiePath).Value;
            await _actorService.UpgradeActorAsync(id, token, request.ActorCreateRequest);
            return RedirectToAction("Index", "Actor");
        }

        /// <summary>
        /// Delete actor (Post).
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> DeleteActor(int id)
        {
            var token = User.FindFirst(ClaimTypes.CookiePath).Value;
            await _actorService.DeleteActorAsync(id, token);
            return RedirectToAction("Index", "Actor");
        }
    }
}
