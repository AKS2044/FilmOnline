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
    public class CommentController : ControllerBase
    {
        private readonly ICommentManager _commentManager;

        public CommentController(ICommentManager commentManager)
        {
            _commentManager = commentManager ?? throw new ArgumentNullException(nameof(commentManager));
        }

        [HttpPost("add")]
        public async Task<IActionResult> CreateAsync(CommentCreateRequest request)
        {
            DateTime dateSet = DateTime.Now;
            CommentDto commentDto = new()
            {
                Comments = request.Comments,
                UserName = request.UserName,
                PathPhoto = request.PathPhoto,
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

        [HttpDelete("")]
        public async Task DeleteAsync(int id)
        {
            await _commentManager.DeleteAsync(id);
        }

        //[OwnAuthorizeAdmin]
        [HttpPut("")]
        public async Task UpdateCommentAsync(CommentDto commentDto)
        {
            if (commentDto.Comments is not null)
            {
                await _commentManager.UpdateAsync(commentDto);
            }
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllComment(int filmId)
        {
            var comments = await _commentManager.GetAllAsync(filmId);

            return Ok(comments);
        }

        [HttpPost("setLike")]
        public async Task<IActionResult> SetLikeComment([FromBody] CommentDto commentDto)
        {
            await _commentManager.SetLikeAsync(commentDto.Id);

            return Ok();
        }

        [HttpPost("setDislike")]
        public async Task<IActionResult> SetDisLikeComment([FromBody] CommentDto commentDto)
        {
            await _commentManager.SetDisLikeAsync(commentDto.Id);

            return Ok();
        }
    }
}