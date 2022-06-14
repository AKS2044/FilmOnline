using FilmOnline.Web.Shared.Models.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmOnline.Web.Interfaces
{
    /// <summary>
    /// Genre service.
    /// </summary>
    public interface IGenreService
    {
        /// <summary>
        /// Add Genre.
        /// </summary>
        /// <param name="value">Object.</param>
        /// <param name="token">Jwt token.</param>
        Task AddGenreAsync(string value, string token);

        /// <summary>
        /// Delete genre.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="token">Jwt token.</param>
        Task DeleteGenreAsync(int id, string token);

        /// <summary>
        /// Upgrade genre.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="token">Jwt token.</param>
        /// <param name="value">New name.</param>
        Task UpgradeGenreAsync(int id, string token, string value);

        /// <summary>
        /// Get all genre.
        /// </summary>
        /// <returns>Genre collection.</returns>
        Task<IEnumerable<GenreModelResponse>> GetAllGenreAsync();
    }
}
