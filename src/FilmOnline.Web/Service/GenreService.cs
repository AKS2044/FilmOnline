using FilmOnline.Web.Interfaces;
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
    /// <inheritdoc cref="IGenreService"/>
    public class GenreService : IGenreService
    {
        private readonly HttpClient _httpClient;

        public GenreService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task AddGenreAsync(string value, string token)
        {
            GenreCreateRequest model = new()
            {
                Genres = value
            };
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/Genre/addGenre")
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

        public async Task DeleteGenreAsync(int id, string token)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, $"/api/Genre/{id}");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            using var response = await _httpClient.SendAsync(request);

            // throw exception on error response
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadFromJsonAsync<Dictionary<string, string>>();
                throw new Exception(error["message"]);
            }
        }

        public async Task<IEnumerable<GenreModelResponse>> GetAllGenreAsync(string token)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/Country/allGenre");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            using var response = await _httpClient.SendAsync(request);

            // throw exception on error response
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadFromJsonAsync<Dictionary<string, string>>();
                throw new Exception(error["message"]);
            }

            var countries = await response.Content.ReadFromJsonAsync<List<GenreModelResponse>>();
            return countries;
        }

        public async Task UpgradeGenreAsync(int id, string token, string value)
        {
            GenreCreateRequest model = new()
            {
                Genres = value
            };

            var request = new HttpRequestMessage(HttpMethod.Put, $"/api/Genre/{id}")
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
    }
}
