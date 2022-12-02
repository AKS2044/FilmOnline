using FilmOnline.Data.Models;
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
    public class StageManagerController : ControllerBase
    {
        private readonly IStageManagerManager _stageManagerManager;

        public StageManagerController(IStageManagerManager stageManagerManager)
        {
            _stageManagerManager = stageManagerManager ?? throw new ArgumentNullException(nameof(stageManagerManager));
        }

        [OwnAuthorizeAdmin]
        [HttpPost("add")]
        public async Task<IActionResult> CreateAsync([FromBody] StageManagerCreateRequest request)
        {
            var stageManagers = await _stageManagerManager.GetAllAsync();

            foreach (var item in stageManagers)
            {
                if (item.StageManagers == request.StageManagers)
                {
                    return BadRequest(new { message = "Данный режиссер уже существует " });
                }
            }
            StageManagerDto stageManagerDto = new()
            {
                StageManagers = request.StageManagers
            };

            if (ModelState.IsValid)
            {
                await _stageManagerManager.CreateAsync(stageManagerDto);
            }

            return Ok();
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllActor()
        {
            var stageManagers = await _stageManagerManager.GetAllAsync();

            return Ok(stageManagers);
        }

        [OwnAuthorizeAdmin]
        [HttpDelete("")]
        public async Task DeleteAsync(int id)
        {
            await _stageManagerManager.DeleteAsync(id);
        }

        [OwnAuthorizeAdmin]
        [HttpPut("")]
        public async Task UpdateStageManagerAsync(StageManagerDto stageManagerDto, int id)
        {
            StageManagerDto result = new()
            {
                Id = id,
                StageManagers = stageManagerDto.StageManagers
            };
            await _stageManagerManager.UpdateAsync(result);
        }
    }
}