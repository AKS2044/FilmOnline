using FilmOnline.Data.Models;
using FilmOnline.Logic.Exceptions;
using FilmOnline.Logic.Interfaces;
using FilmOnline.Logic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmOnline.Logic.Managers
{
    /// <inheritdoc cref="ICommentManager"/>
    public class CommentManager : ICommentManager
    {
        private readonly IRepositoryManager<Comment> _commentRepository;
        private readonly IRepositoryManager<CommentFilmUser> _commentFilmUserRepository;

        public CommentManager(IRepositoryManager<Comment> commentRepository, IRepositoryManager<CommentFilmUser> commentFilmUserRepository)
        {
            _commentRepository = commentRepository ?? throw new ArgumentNullException(nameof(commentRepository));
            _commentFilmUserRepository = commentFilmUserRepository ?? throw new ArgumentNullException(nameof(commentRepository));
        }

        public async Task CreateAsync(CommentDto commentDto, CommentFilmUserDto commentFilmUserDto)
        {
            //Сделать проверки на ошибки и правильность моделей
            var comment = new Comment()
            {
                Comments = commentDto.Comments,
                DateSet = commentDto.DateSet,
                Like = commentDto.Like,
                Dislike = commentDto.Dislike,
            };

            await _commentRepository.CreateAsync(comment);
            await _commentRepository.SaveChangesAsync();

            CommentFilmUser commentFilmUser = new()
            {
                FilmId = commentFilmUserDto.FilmId,
                CommentId = comment.Id,
                UserId = commentFilmUserDto.UserId
            };
            await _commentFilmUserRepository.CreateAsync(commentFilmUser);
            await _commentFilmUserRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<CommentDto>> GetAllAsync(int filmId)
        {
            var commentDto = new List<CommentDto>();

            //var actors = await _actorRepository
            //    .GetAll()
            //    .Select(a => new Actor
            //    {
            //        Id = a.Id, 
            //        FirstName = a.FirstName,
            //        LastName = a.LastName,
            //        SecondName = a.SecondName
            //    }).ToListAsync();

            //foreach (var item in actors)
            //{
            //    actorDtos.Add(new ActorDto
            //    {
            //        Id = item.Id,
            //        FirstName = item.FirstName,
            //        LastName = item.LastName,
            //        SecondName = item.SecondName
            //    });
            //}
            return commentDto;
        }

        public async Task DeleteAsync(int id)
        {
            //var actor = await _actorRepository
            //   .GetAll()
            //   .SingleOrDefaultAsync(r => r.Id == id);

            //if (actor is null)
            //{
            //    throw new NotFoundException($"'{nameof(id)}' record not found.", nameof(id));
            //}

            //_commentRepository.Delete(actor);
            //await _commentRepository.SaveChangesAsync();
        }

        public async Task UpdateAsync(CommentDto commentDto)
        {
            //var actor = await _commentRepository.GetEntityAsync(c => c.Id == actorDto.Id);

            //if (actorDto.FirstName != actor.FirstName && actorDto.FirstName is not null)
            //{
            //    actor.FirstName = actorDto.FirstName;
            //}

            //if (actorDto.LastName != actor.LastName && actorDto.LastName is not null)
            //{
            //    actor.LastName = actorDto.LastName;
            //}

            //if (actorDto.SecondName != actor.SecondName && actorDto.SecondName is not null)
            //{
            //    actor.SecondName = actorDto.SecondName;
            //}
            //await _actorRepository.SaveChangesAsync();
        }
    }
}