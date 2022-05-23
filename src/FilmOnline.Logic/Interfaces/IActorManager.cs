using FilmOnline.Logic.Models;
using FilmOnline.Web.Shared.Models.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmOnline.Logic.Interfaces
{
    /// <summary>
    /// Actor manager.
    /// </summary>
    public interface IActorManager
    {
        /// <summary>
        /// Create actor.
        /// </summary>
        /// <param name="model">Actor data transfer object.</param>
        Task CreateAsync(ActorDto actorDto);

        /// <summary>
        /// Get actor by identifier.
        /// </summary>
        /// <param name="id">Identifier.</param>
        Task<FilmModelResponse> GetByIdAsync(int id);

        /// <summary>
        /// Update actor by identifier.
        /// </summary>
        /// <param name="model">Actor data transfer object.</param>
        Task UpdateAsync(ActorDto model);

        /// <summary>
        /// Delete actor by identifier.
        /// </summary>
        /// <param name="id">Actor identifier.</param>
        Task DeleteAsync(int id);

        /// <summary>
        /// Get all actors.
        /// </summary>
        Task<IEnumerable<ActorDto>> GetAllAsync();
    }
}