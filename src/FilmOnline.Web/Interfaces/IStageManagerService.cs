using FilmOnline.Web.Shared.Models.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmOnline.Web.Interfaces
{
    /// <summary>
    /// Stage manager service.
    /// </summary>
    public interface IStageManagerService
    {
        /// <summary>
        /// Add Stage manager.
        /// </summary>
        /// <param name="value">Object.</param>
        /// <param name="token">Jwt token.</param>
        Task AddStageManagerAsync(string value, string token);

        /// <summary>
        /// Delete stage manager.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="token">Jwt token.</param>
        Task DeleteStageManagerAsync(int id, string token);

        /// <summary>
        /// Upgrade stage manager.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="token">Jwt token.</param>
        /// <param name="value">New name.</param>
        Task UpgradeStageManagerAsync(int id, string token, string value);

        /// <summary>
        /// Get all stage manager.
        /// </summary>
        /// <returns>Stage manager collection.</returns>
        Task<IEnumerable<StageManagerModelResponse>> GetAllStageManagerAsync();
    }
}
