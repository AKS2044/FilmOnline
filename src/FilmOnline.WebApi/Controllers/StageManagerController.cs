using FilmOnline.Logic.Interfaces;
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

        [OwnAuthorize]
        [HttpPost("add")]
        public async Task<IActionResult> CreateAsync([FromBody] StageManagerCreateRequest request)
        {
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
            var countries = await _stageManagerManager.GetAllAsync();

            return Ok(countries);
        }

        [OwnAuthorize]
        [HttpDelete("")]
        public async Task DeleteAsync(int id)
        {
            await _stageManagerManager.DeleteAsync(id);
        }

        [OwnAuthorize]
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