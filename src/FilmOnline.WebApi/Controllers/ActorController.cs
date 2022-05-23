using FilmOnline.Logic.Interfaces;
using FilmOnline.Logic.Models;
using FilmOnline.Web.Shared.Models.Request;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FilmOnline.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly IActorManager _actorManager;

        public ActorController(IActorManager actorManager)
        {
            _actorManager = actorManager ?? throw new ArgumentNullException(nameof(actorManager));
        }

        [HttpPost("addActor")]
        public async Task<IActionResult> CreateAsync([FromBody] ActorCreateRequest request)
        {
            ActorDto actorDto = new()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                SecondName = request.SecondName
            };

            if (ModelState.IsValid)
            {
                await _actorManager.CreateAsync(actorDto);
            }

            return Ok();
        }

        [HttpGet("allActor")]
        public async Task<IActionResult> GetAllActor()
        {
            var actors = await _actorManager.GetAllAsync();

            return Ok(actors);
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            await _actorManager.DeleteAsync(id);
        }
    }
}