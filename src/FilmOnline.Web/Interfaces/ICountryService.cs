using FilmOnline.Web.Shared.Models.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmOnline.Web.Interfaces
{
    /// <summary>
    /// Country service.
    /// </summary>
    public interface ICountryService
    {
        /// <summary>
        /// Add country.
        /// </summary>
        /// <param name="value">Object.</param>
        /// <param name="token">Jwt token.</param>
        Task AddCountryAsync(string value, string token);

        /// <summary>
        /// Delete country.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="token">Jwt token.</param>
        Task DeleteCountryAsync(int id, string token);

        /// <summary>
        /// Upgrade country.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="token">Jwt token.</param>
        /// <param name="value">New name.</param>
        Task UpgradeCountryAsync(int id, string token, string value);

        /// <summary>
        /// Get all country.
        /// </summary>
        /// <param name="token">Jwt token.</param>
        /// <returns>Country collection.</returns>
        Task<IEnumerable<CountryModelResponse>> GetAllCountryAsync(string token);
    }
}
