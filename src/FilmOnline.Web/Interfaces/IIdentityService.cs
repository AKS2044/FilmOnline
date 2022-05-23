using FilmOnline.Web.Shared.Models.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmOnline.Web.Interfaces
{
    /// <summary>
    /// Identity service.
    /// </summary>
    public interface IIdentityService
    {
        /// <summary>
        /// Login.
        /// </summary>
        /// <param name="value">Object.</param>
        Task<(IList<string> roles, string userName, string token)> LoginAsync(object value);

        /// <summary>
        /// Register.
        /// </summary>
        /// <param name="value">Object.</param>
        /// <returns>Jwt token.</returns>
        Task<(string Email, string Password, string PasswordConfirm)> RegisterAsync(object value);

        /// <summary>
        /// Get user profile by id.
        /// </summary>
        /// /// <param name="token">Jwt token.</param>
        /// /// <param name="userId">User id.</param>
        /// <returns>Profile user.</returns>
        Task<ProfileUserResponse> GetProfileByNameAsync(string userId, string token);

        /// <summary>
        /// Get all user.
        /// </summary>
        /// /// <param name="token">Jwt token.</param>
        /// <returns>List user.</returns>
        Task<List<ProfileUserResponse>> GetAllUsersAsync(string token);

        /// <summary>
        /// Delete user by id.
        /// </summary>
        /// /// <param name="token">Jwt token.</param>
        /// /// <param name="Id">User id.</param>
        Task DeleteUserAsync(string Id, string token);
    }
}