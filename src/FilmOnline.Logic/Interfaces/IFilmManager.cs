using FilmOnline.Logic.Models;
using FilmOnline.Web.Shared.Models;
using FilmOnline.Web.Shared.Models.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmOnline.Logic.Interfaces
{
    /// <summary>
    /// Film manager.
    /// </summary>
    public interface IFilmManager
    {
        /// <summary>
        /// Create film.
        /// </summary>
        /// <param name="filmDto">film data transfer object.</param>
        /// /// <param name="filmActorDto">List filmActor data transfer object.</param>
        /// /// <param name="filmGenreDto">List filmGenre data transfer object.</param>
        /// /// <param name="filmCountryDto">List filmCountry data transfer object.</param>
        /// /// <param name="filmStageManagerDto">List filmStageManager data transfer object.</param>
        Task CreateAsync(FilmDto filmDto,
            List<FilmActorDto> filmActorDto,
            List<FilmGenreDto> filmGenreDto,
            List<FilmCountryDto> filmCountryDto,
            List<FilmStageManagerDto> filmStageManagerDto);

        /// <summary>
        /// Get film by identifier.
        /// </summary>
        /// <param name="id">Identifier.</param>
        /// <returns>Film data transfer object.</returns>
        Task<FilmModelResponse> GetByIdAsync(int id);

        /// <summary>
        /// Get film by identifier.
        /// </summary>
        /// <param name="id">Identifier.</param>
        /// <returns>Film data transfer object.</returns>
        Task<FilmUpgradeModel> GetByIdForUpgradeAsync(int id);

        /// <summary>
        /// Get film by name.
        /// </summary>
        /// <param name="nameSearch">Film Name.</param>
        /// <returns>FilmShortModelResponse.</returns>
        Task<FilmShortModelResponse> GetByNameAsync(string nameSearch);

        /// <summary>
        /// Get all films by genre.
        /// </summary>
        /// <param name="idGenre">Identifier.</param>
        /// <returns>Film data transfer object.</returns>
        Task<IEnumerable<FilmDto>> GetFilmByGenreAsync(int idGenre);

        /// <summary>
        /// Update film by identifier.
        /// </summary>
        /// <param name="model">film data transfer object.</param>
        Task UpdateAsync(FilmDto model);

        /// <summary>
        /// Delete film by identifier.
        /// </summary>
        /// <param name="id">Film identifier.</param>
        Task DeleteAsync(int id);

        /// <summary>
        /// Get all short information Film.
        /// </summary>
        /// <returns>Film data transfer objects.</returns>
        Task<IEnumerable<FilmDto>> GetAllShortAsync();

        /// <summary>
        /// Get all short information Film.
        /// </summary>
        Task AddScoreFilmAsync(int idFilm, int score);

        /// <summary>
        /// Get random Film.
        /// </summary>
        /// <returns>integer.</returns>
        Task<int> GetRandomFilmAsync();

        /// <summary>
        /// Get total score film.
        /// </summary>
        /// <returns>Float result.</returns>
        Task<float> GetTotalScoreFilm(int idFilm);
    }
}