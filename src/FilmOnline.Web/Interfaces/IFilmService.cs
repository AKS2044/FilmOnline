using FilmOnline.Web.Shared.Models;
using FilmOnline.Web.Shared.Models.Request;
using FilmOnline.Web.Shared.Models.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmOnline.Web.Interfaces
{
    /// <summary>
    /// Film service.
    /// </summary>
    public interface IFilmService
    {
        /// <summary>
        /// Add film.
        /// </summary>
        /// <param name="model">Object.</param>
        /// <param name="token">Jwt token.</param>
        Task AddAsync(FilmCreateRequest model, string token);

        /// <summary>
        /// Upgrade film.
        /// </summary>
        /// <param name="model">Object.</param>
        /// <param name="token">Jwt token.</param>
        Task UpgradeFilmAsync(FilmCreateRequest model, string token);

        /// <summary>
        /// Delete film.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="token">Jwt token.</param>
        Task DeleteFilmAsync(int id, string token);

        /// <summary>
        /// Get all short information films.
        /// </summary>
        /// <returns>Film collection.</returns>
        Task<IEnumerable<FilmShortModelResponse>> GetAllShortAsync();

        /// <summary>
        /// Get all stage manager.
        /// </summary>
        /// <returns>Stage manager collection.</returns>
        Task<IEnumerable<StageManagerModelResponse>> GetAllStageManagerAsync();

        /// <summary>
        /// Get film by id.
        /// </summary>
        /// <param name="id">Film id.</param>
        /// <returns>Film.</returns>
        Task<FilmModelResponse> GetByIdAsync(int id);

        /// <summary>
        /// Get random film by id.
        /// </summary>
        /// <returns>Film collection.</returns>
        Task<FilmModelResponse> GetRandomFilmByIdAsync();

        /// <summary>
        /// Get all films by name.
        /// </summary>
        /// <param name="name">Film name.</param>
        /// <returns>Film collection.</returns>
        Task<FilmShortModelResponse> GetByNameAsync(string name);

        /// <summary>
        /// Get all films by genre id.
        /// </summary>
        /// <param name="genreId">Genre id.</param>
        /// <returns>Film collection.</returns>
        Task<IEnumerable<FilmShortModelResponse>> GetFilmByGenreIdAsync(int genreId);
    }
}