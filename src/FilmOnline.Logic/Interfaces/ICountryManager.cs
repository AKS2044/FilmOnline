using FilmOnline.Logic.Models;
using FilmOnline.Web.Shared.Models.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmOnline.Logic.Interfaces
{
    /// <summary>
    /// Country manager.
    /// </summary>
    public interface ICountryManager
    {
        /// <summary>
        /// Create state.
        /// </summary>
        /// <param name="model">State data transfer object.</param>
        Task CreateAsync(StateDto stateDto);

        /// <summary>
        /// Get state by identifier.
        /// </summary>
        /// <param name="id">Identifier.</param>
        Task<FilmModelResponse> GetByIdAsync(int id);

        /// <summary>
        /// Update state by identifier.
        /// </summary>
        /// <param name="model">State data transfer object.</param>
        Task UpdateAsync(StateDto stateDto);

        /// <summary>
        /// Delete state by identifier.
        /// </summary>
        /// <param name="id">State identifier.</param>
        Task DeleteAsync(int id);

        /// <summary>
        /// Get all state.
        /// </summary>
        Task<IEnumerable<StateDto>> GetAllAsync();
    }
}