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
    public class CommentController : ControllerBase
    {
        private readonly ICommentManager _commentManager;

        public CommentController(ICommentManager commentManager)
        {
            _commentManager = commentManager ?? throw new ArgumentNullException(nameof(commentManager));
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync(CommentCreateRequest request)
        {
            DateTime dateSet = DateTime.Now;
            CommentDto commentDto = new()
            {
                Comments = request.Comments,
                DateSet = dateSet.ToLongDateString()
            };

            CommentFilmUserDto commentFilmUserDto = new()
            {
                FilmId = request.FilmId,
                UserId = request.UserId,
            };

            if (ModelState.IsValid)
            {
                await _commentManager.CreateAsync(commentDto, commentFilmUserDto);
            }

            return Ok();
        }

        //[HttpGet("getAll")]
        //public async Task<IActionResult> GetAllActor()
        //{
        //    var actors = await _actorManager.GetAllAsync();

        //    return Ok(actors);
        //}

        //[OwnAuthorizeAdmin]
        //[HttpDelete("")]
        //public async Task DeleteAsync(int id)
        //{
        //    await _actorManager.DeleteAsync(id);
        //}

        //[OwnAuthorizeAdmin]
        //[HttpPut("")]
        //public async Task UpdateActorAsync(ActorDto actorDto, int id)
        //{
        //    ActorDto result = new()
        //    {
        //        Id = id,
        //        FirstName = actorDto.FirstName,
        //        LastName = actorDto.LastName,
        //        SecondName = actorDto.SecondName
        //    };
        //    await _actorManager.UpdateAsync(result);
        //}
    }
}