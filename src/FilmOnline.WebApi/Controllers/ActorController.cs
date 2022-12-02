using FilmOnline.Logic.Interfaces;
using FilmOnline.Logic.Managers;
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
    public class ActorController : ControllerBase
    {
        private readonly IActorManager _actorManager;

        public ActorController(IActorManager actorManager)
        {
            _actorManager = actorManager ?? throw new ArgumentNullException(nameof(actorManager));
        }

        [OwnAuthorizeAdmin]
        [HttpPost("add")]
        public async Task<IActionResult> CreateAsync([FromBody] ActorCreateRequest request)
        {
            var actors = await _actorManager.GetAllAsync();

            foreach (var item in actors)
            {
                if (item.FirstName == request.FirstName && item.LastName == request.LastName)
                {
                    return BadRequest(new { message = "Данный актер уже существует " });
                }
            }
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

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllActor()
        {
            var actors = await _actorManager.GetAllAsync();

            return Ok(actors);
        }

        [OwnAuthorizeAdmin]
        [HttpDelete("")]
        public async Task DeleteAsync(int id)
        {
            await _actorManager.DeleteAsync(id);
        }

        [OwnAuthorizeAdmin]
        [HttpPut("")]
        public async Task UpdateActorAsync(ActorDto actorDto, int id)
        {
            ActorDto result = new()
            {
                Id = id,
                FirstName = actorDto.FirstName,
                LastName = actorDto.LastName,
                SecondName = actorDto.SecondName
            };
            await _actorManager.UpdateAsync(result);
        }
    }
}