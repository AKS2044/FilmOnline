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
        Task<(string email, string userName, string password, string passwordConfirm)> RegisterAsync(object value);

        /// <summary>
        /// Get user profile by id.
        /// </summary>
        /// <param name="token">Jwt token.</param>
        /// <param name="userId">User id.</param>
        /// <returns>Profile user.</returns>
        Task<ProfileUserResponse> GetProfileByNameAsync(string userId, string token);

        /// <summary>
        /// Get all user.
        /// </summary>
        /// <param name="token">Jwt token.</param>
        /// <returns>List user.</returns>
        Task<List<ProfileUserResponse>> GetAllUsersAsync(string token);

        /// <summary>
        /// Delete user by id.
        /// </summary>
        /// <param name="token">Jwt token.</param>
        /// <param name="Id">User id.</param>
        Task DeleteUserAsync(string Id, string token);

        /// <summary>
        /// Check user email.
        /// </summary>
        /// <param name="email">User Email.</param>
        Task<bool> CheckEmailAsync(string email);

        /// <summary>
        /// Check user name.
        /// </summary>
        /// <param name="name">User name.</param>
        Task<bool> CheckNameAsync(string name);

        /// <summary>
        /// Add favourite film by user.
        /// </summary>
        /// <param name="token">Jwt token.</param>
        /// <param name="filmId">Film id.</param>
        /// <param name="userName">User name.</param>
        Task AddFavouriteFilmAsync(string userName, int filmId, string token);

        /// <summary>
        /// Get all favourite film by user.
        /// </summary>
        /// <param name="token">Jwt token.</param>
        /// <param name="userName">User name.</param>
        /// <returns>Short model response.</returns>
        Task<List<FilmShortModelResponse>> GetFavouriteFilmAsync(string userName, string token);

        /// <summary>
        /// Delete favourite film by id.
        /// </summary>
        /// <param name="token">Jwt token.</param>
        /// <param name="userName">User name.</param>
        /// <param name="idFilm">Film id.</param>
        Task DeleteFavouriteFilmUserAsync(int idFilm, string userName, string token);

        /// <summary>
        /// Add watch later film by user.
        /// </summary>
        /// <param name="token">Jwt token.</param>
        /// <param name="filmId">Film id.</param>
        /// <param name="userName">User name.</param>
        Task AddWatchLaterFilmAsync(string userName, int filmId, string token);

        /// <summary>
        /// Get all watch later film by user.
        /// </summary>
        /// <param name="token">Jwt token.</param>
        /// <param name="userName">User name.</param>
        /// <returns>Short model response.</returns>
        Task<List<FilmShortModelResponse>> GetWatchLaterFilmAsync(string userName, string token);

        /// <summary>
        /// Delete watch later film by id.
        /// </summary>
        /// <param name="token">Jwt token.</param>
        /// <param name="userName">User name.</param>
        /// <param name="idFilm">Film id.</param>
        Task DeleteWatchLaterFilmUserAsync(int idFilm, string userName, string token);
    }
}