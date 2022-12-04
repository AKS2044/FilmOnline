using FilmOnline.Logic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmOnline.Logic.Interfaces
{
    public interface ICommentManager
    {
        /// <summary>
        /// Create comment.
        /// </summary>
        /// <param name="commentDto">comment data transfer object.</param>
        /// <param name="commentFilmUserDto">commentFilmUserDto data transfer object.</param>
        Task CreateAsync(CommentDto commentDto, CommentFilmUserDto commentFilmUserDto);

        /// <summary>
        /// Update comment by identifier.
        /// </summary>
        /// <param name="commentDto">comment data transfer object.</param>
        Task UpdateAsync(CommentDto commentDto);

        /// <summary>
        /// Delete comment by identifier.
        /// </summary>
        /// <param name="id">comment identifier.</param>
        Task DeleteAsync(int id);

        /// <summary>
        /// Get all comments by film.
        /// </summary>
        /// <param name="filmId">film identifier.</param>
        Task<IEnumerable<CommentDto>> GetAllAsync(int filmId);
    }
}