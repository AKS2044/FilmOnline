using FilmOnline.Web.Shared.Models.Request;
using FilmOnline.Web.Shared.Models.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmOnline.Web.Interfaces
{
    /// <summary>
    /// Actor service.
    /// </summary>
    public interface IActorService
    {
        /// <summary>
        /// Add Actor.
        /// </summary>
        /// <param name="model">Object.</param>
        /// <param name="token">Jwt token.</param>
        Task AddActorAsync(ActorCreateRequest model, string token);

        /// <summary>
        /// Delete actor.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="token">Jwt token.</param>
        Task DeleteActorAsync(int id, string token);

        /// <summary>
        /// Upgrade Actor.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="token">Jwt token.</param>
        /// <param name="model">Object.</param>
        Task UpgradeActorAsync(int id, string token, ActorCreateRequest model);

        /// <summary>
        /// Get all actor.
        /// </summary>
        /// <returns>Country collection.</returns>
        Task<IEnumerable<ActorModelResponse>> GetAllActorAsync();
    }
}
