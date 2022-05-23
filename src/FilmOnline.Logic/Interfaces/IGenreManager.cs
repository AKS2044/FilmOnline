using FilmOnline.Logic.Models;
using FilmOnline.Web.Shared.Models.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmOnline.Logic.Interfaces
{
    public interface IGenreManager
    {
        /// <summary>
        /// Create genre.
        /// </summary>
        /// <param name="genreDto">genre data transfer object.</param>
        Task CreateAsync(GenreDto genreDto);

        /// <summary>
        /// Get genre by identifier.
        /// </summary>
        /// <param name="id">Identifier.</param>
        Task<FilmModelResponse> GetByIdAsync(int id);

        /// <summary>
        /// Update genre by identifier.
        /// </summary>
        /// <param name="model">genre data transfer object.</param>
        Task UpdateAsync(GenreDto genreDto);

        /// <summary>
        /// Delete genre by identifier.
        /// </summary>
        /// <param name="id">genre identifier.</param>
        Task DeleteAsync(int id);

        /// <summary>
        /// Get all genre.
        /// </summary>
        Task<IEnumerable<GenreDto>> GetAllAsync();
    }
}