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

        public async Task DeleteAsync(int id)
        {

            var commentFilmUser = await _commentFilmUserRepository
               .GetAll()
               .SingleOrDefaultAsync(r => r.CommentId == id);

            if (commentFilmUser is null)
            {
                throw new NotFoundException($"'{nameof(id)}' record not found.", nameof(id));
            }

            _commentFilmUserRepository.Delete(commentFilmUser);
            await _commentFilmUserRepository.SaveChangesAsync();

            var comment = await _commentRepository
               .GetAll()
               .SingleOrDefaultAsync(r => r.Id == id);

            if (comment is null)
            {
                throw new NotFoundException($"'{nameof(id)}' record not found.", nameof(id));
            }

            _commentRepository.Delete(comment);
            await _commentRepository.SaveChangesAsync();
        }
        public async Task UpdateAsync(CommentDto commentDto)
        {
            var comment = await _commentRepository.GetEntityAsync(c => c.Id == commentDto.Id);

            if (commentDto.Comments != comment.Comments && commentDto.Comments is not null)
            {
                comment.Comments = commentDto.Comments;
            }
            await _commentRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<CommentDto>> GetAllAsync(int filmId)
        {
            var commentDto = new List<CommentDto>();

            var commentFilmUserIds = await _commentFilmUserRepository.GetAll().Where(c => c.FilmId == filmId).Select(c => c.CommentId).ToListAsync();
            var comments = await _commentRepository.GetAll().Where(c => commentFilmUserIds.Contains(c.Id)).ToListAsync();

            foreach (var item in comments)
            {
                commentDto.Add(new CommentDto
                {
                    Id = item.Id,
                    Comments = item.Comments,
                    DateSet = item.DateSet,
                    Dislike = item.Dislike,
                    Like = item.Like,
                });
            }
            return commentDto;
        }
    }
}