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
    /// <inheritdoc cref="IFilmService"/>
    public class FilmService : IFilmService
    {
        private readonly HttpClient _httpClient;

        public FilmService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task AddAsync(object value, string token)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/Film/addfilm")
            {
                Content = new StringContent(JsonSerializer.Serialize(value), Encoding.UTF8, "application/json")
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

        public async Task AddCountryAsync(string value, string token)
        {
            CountryCreateRequest model = new()
            {
                Country = value
            };
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/Country/addCountry")
            {
                Content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json")
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

        public async Task DeleteFilmAsync(int id, string token)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, $"/api/Film/DeleteFilm{id}");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            using var response = await _httpClient.SendAsync(request);

            // throw exception on error response
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadFromJsonAsync<Dictionary<string, string>>();
                throw new Exception(error["message"]);
            }
        }

        public async Task DeleteCountryAsync(int id, string token)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, $"/api/Country/{id}");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            using var response = await _httpClient.SendAsync(request);

            // throw exception on error response
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadFromJsonAsync<Dictionary<string, string>>();
                throw new Exception(error["message"]);
            }
        }

        public async Task<IEnumerable<FilmShortModelResponse>> GetAllShortAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/Film/allFilms");

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

        public async Task<FilmModelResponse> GetByIdAsync(int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"/api/Film/{id}");

            using var response = await _httpClient.SendAsync(request);

            // throw exception on error response
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadFromJsonAsync<Dictionary<string, string>>();
                throw new Exception(error["message"]);
            }

            var film = await response.Content.ReadFromJsonAsync<FilmModelResponse>();
            return film;
        }

        public async Task<FilmUpgradeModel> GetByIdUpgradeAsync(int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"/api/Film/Upgrade{id}");

            using var response = await _httpClient.SendAsync(request);

            // throw exception on error response
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadFromJsonAsync<Dictionary<string, string>>();
                throw new Exception(error["message"]);
            }

            var film = await response.Content.ReadFromJsonAsync<FilmUpgradeModel>();
            return film;
        }

        public async Task<FilmShortModelResponse> GetByNameAsync(string name)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/Film/name")
            {
                Content = new StringContent(JsonSerializer.Serialize(name), Encoding.UTF8, "application/json")
            };

            using var response = await _httpClient.SendAsync(request);

            var film = await response.Content.ReadFromJsonAsync<FilmShortModelResponse>();
            return film;
        }

        public async Task<IEnumerable<GenreModelResponse>> GetAllGenreAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/Genre/allGenre");
            using var response = await _httpClient.SendAsync(request);

            // throw exception on error response
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadFromJsonAsync<Dictionary<string, string>>();
                throw new Exception(error["message"]);
            }

            var genres = await response.Content.ReadFromJsonAsync<List<GenreModelResponse>>();
            return genres;
        }

        public async Task<IEnumerable<CountryModelResponse>> GetAllCountryAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/Country/allCountry");
            using var response = await _httpClient.SendAsync(request);

            // throw exception on error response
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadFromJsonAsync<Dictionary<string, string>>();
                throw new Exception(error["message"]);
            }

            var countries = await response.Content.ReadFromJsonAsync<List<CountryModelResponse>>();
            return countries;
        }

        public async Task<IEnumerable<ActorModelResponse>> GetAllActorAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/Actor/allActor");
            using var response = await _httpClient.SendAsync(request);

            // throw exception on error response
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadFromJsonAsync<Dictionary<string, string>>();
                throw new Exception(error["message"]);
            }

            var actors = await response.Content.ReadFromJsonAsync<List<ActorModelResponse>>();
            return actors;
        }

        public async Task<IEnumerable<StageManagerModelResponse>> GetAllStageManagerAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/StageManager/allStageManager");
            using var response = await _httpClient.SendAsync(request);

            // throw exception on error response
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadFromJsonAsync<Dictionary<string, string>>();
                throw new Exception(error["message"]);
            }

            var actors = await response.Content.ReadFromJsonAsync<List<StageManagerModelResponse>>();
            return actors;
        }

        public async Task<IEnumerable<FilmShortModelResponse>> GetFilmByGenreIdAsync(int genreId)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/Film/genre")
            {
                Content = new StringContent(JsonSerializer.Serialize(genreId), Encoding.UTF8, "application/json")
            };
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

        public async Task<FilmModelResponse> GetRandomFilmByIdAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"/api/Film/randomFilmId");

            using var response = await _httpClient.SendAsync(request);

            // throw exception on error response
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadFromJsonAsync<Dictionary<string, string>>();
                throw new Exception(error["message"]);
            }

            var film = await response.Content.ReadFromJsonAsync<FilmModelResponse>();
            return film;
        }
    }
}