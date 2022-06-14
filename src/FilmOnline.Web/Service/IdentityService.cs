using FilmOnline.Web.Interfaces;
using FilmOnline.Web.Shared.Models;
using FilmOnline.Web.Shared.Models.Request;
using FilmOnline.Web.Shared.Models.Responses;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FilmOnline.Web.Service
{
    /// <inheritdoc cref="IIdentityService"/>
    public class IdentityService : IIdentityService
    {
        private readonly HttpClient _httpClient;

        public IdentityService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<ProfileUserResponse> GetProfileByNameAsync(string userName, string token)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"/api/User/userProfile")
            {
                Content = new StringContent(JsonSerializer.Serialize(userName), Encoding.UTF8, "application/json")
            };
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            using var response = await _httpClient.SendAsync(request);

            // throw exception on error response
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadFromJsonAsync<Dictionary<string, string>>();
                throw new Exception(error["message"]);
            }

            var profile = await response.Content.ReadFromJsonAsync<ProfileUserResponse>();
            return profile;
        }

        public async Task<List<ProfileUserResponse>> GetAllUsersAsync(string token)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/User/allUsers");

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            using var response = await _httpClient.SendAsync(request);

            // throw exception on error response
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadFromJsonAsync<Dictionary<string, string>>();
                throw new Exception(error["message"]);
            }

            var profile = await response.Content.ReadFromJsonAsync<List<ProfileUserResponse>>();
            return profile;
        }

        public async Task<(IList<string> roles, string userName, string token)> LoginAsync(object value)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "api/user/login")
            {
                Content = new StringContent(JsonSerializer.Serialize(value), Encoding.UTF8, "application/json")
            };

            using var response = await _httpClient.SendAsync(request);

            // throw exception on error response
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadFromJsonAsync<Dictionary<string, string>>();
                throw new Exception(error["message"]);
            }

            var record = await response.Content.ReadFromJsonAsync<UserAuthModel>();

            return (record.Roles, record.UserName, record.Token);
        }

        public async Task<(string Email, string Password, string PasswordConfirm)> RegisterAsync(object value)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "api/user/registration")
            {
                Content = new StringContent(JsonSerializer.Serialize(value), Encoding.UTF8, "application/json")
            };

            using var response = await _httpClient.SendAsync(request);

            // throw exception on error response
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadFromJsonAsync<Dictionary<string, string>>();
                throw new Exception(error["message"]);
            }

            var record = await response.Content.ReadFromJsonAsync<UserRegModel>();

            return (record.Email, record.Password, record.PasswordConfirm);
        }

        public async Task DeleteUserAsync(string id, string token)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, $"/api/User/DeleteUser{id}");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            using var response = await _httpClient.SendAsync(request);

            // throw exception on error response
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadFromJsonAsync<Dictionary<string, string>>();
                throw new Exception(error["message"]);
            }
        }

        public async Task AddFavouriteFilmAsync(string userName, int filmId, string token)
        {
            UserFilmRequest result = new()
            {
                UserName = userName,
                FilmId = filmId
            };
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/Film/AddFavouriteFilm")
            {
                Content = new StringContent(JsonSerializer.Serialize(result), Encoding.UTF8, "application/json")
            };
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            using var response = await _httpClient.SendAsync(request);

            // throw exception on error response
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadFromJsonAsync<Dictionary<string, string>>();
                throw new Exception(error["message"]);
            }
        }

            public async Task<List<FilmShortModelResponse>> GetFavouriteFilmAsync(string userName, string token)
            {
                var request = new HttpRequestMessage(HttpMethod.Get, $"/api/Film/GetAllFavouriteFilm")
                {
                    Content = new StringContent(JsonSerializer.Serialize(userName), Encoding.UTF8, "application/json")
                };
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

                using var response = await _httpClient.SendAsync(request);

                // throw exception on error response
                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadFromJsonAsync<Dictionary<string, string>>();
                    throw new Exception(error["message"]);
                }

                var films = await response.Content.ReadFromJsonAsync <List<FilmShortModelResponse>>();
                return films;
            }
        public async Task DeleteFavouriteFilmUserAsync(int idFilm, string userName, string token)
        {
            UserFilmRequest result = new()
            {
                UserName = userName,
                FilmId = idFilm
            };
            var request = new HttpRequestMessage(HttpMethod.Delete, "/api/Film/DeleteFavouriteFilm")
            {
                Content = new StringContent(JsonSerializer.Serialize(result), Encoding.UTF8, "application/json")
            };
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            using var response = await _httpClient.SendAsync(request);

            // throw exception on error response
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadFromJsonAsync<Dictionary<string, string>>();
                throw new Exception(error["message"]);
            }
        }

        public async Task AddWatchLaterFilmAsync(string userName, int filmId, string token)
        {
            UserFilmRequest result = new()
            {
                UserName = userName,
                FilmId = filmId
            };
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/Film/AddWatchLaterFilm")
            {
                Content = new StringContent(JsonSerializer.Serialize(result), Encoding.UTF8, "application/json")
            };
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            using var response = await _httpClient.SendAsync(request);

            // throw exception on error response
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadFromJsonAsync<Dictionary<string, string>>();
                throw new Exception(error["message"]);
            }
        }

        public async Task<List<FilmShortModelResponse>> GetWatchLaterFilmAsync(string userName, string token)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"/api/Film/GetAllWatchLaterFilm")
            {
                Content = new StringContent(JsonSerializer.Serialize(userName), Encoding.UTF8, "application/json")
            };
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            using var response = await _httpClient.SendAsync(request);

            // throw exception on error response
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadFromJsonAsync<Dictionary<string, string>>();
                throw new Exception(error["message"]);
            }

            var films = await response.Content.ReadFromJsonAsync<List<FilmShortModelResponse>>();
            return films;
        }

        public async Task DeleteWatchLaterFilmUserAsync(int idFilm, string userName, string token)
        {
            UserFilmRequest result = new()
            {
                UserName = userName,
                FilmId = idFilm
            };
            var request = new HttpRequestMessage(HttpMethod.Delete, "/api/Film/DeleteWatchLaterFilm")
            {
                Content = new StringContent(JsonSerializer.Serialize(result), Encoding.UTF8, "application/json")
            };
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            using var response = await _httpClient.SendAsync(request);

            // throw exception on error response
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadFromJsonAsync<Dictionary<string, string>>();
                throw new Exception(error["message"]);
            }
        }
    }
}