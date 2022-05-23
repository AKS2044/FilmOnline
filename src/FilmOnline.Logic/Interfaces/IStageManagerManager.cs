using FilmOnline.Logic.Models;
using FilmOnline.Web.Shared.Models.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmOnline.Logic.Interfaces
{
    /// <summary>
    /// StageManager manager.
    /// </summary>
    public interface IStageManagerManager
    {
        /// <summary>
        /// Create stageManager.
        /// </summary>
        /// <param name="stageManagerDto">StageManager data transfer object.</param>
        Task CreateAsync(StageManagerDto stageManagerDto);

        /// <summary>
        /// Get stageManager by identifier.
        /// </summary>
        /// <param name="id">Identifier.</param>
        Task<FilmModelResponse> GetByIdAsync(int id);

        /// <summary>
        /// Update stageManager by identifier.
        /// </summary>
        /// <param name="stageManagerDto">StageManager data transfer object.</param>
        Task UpdateAsync(StageManagerDto stageManagerDto);

        /// <summary>
        /// Delete stageManager by identifier.
        /// </summary>
        /// <param name="id">StageManager identifier.</param>
        Task DeleteAsync(int id);

        /// <summary>
        /// Get all stageManagers.
        /// </summary>
        Task<IEnumerable<StageManagerDto>> GetAllAsync();
    }
}