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
    /// <inheritdoc cref="ICountryService"/>
    public class CountryService : ICountryService
    {
        private readonly HttpClient _httpClient;

        public CountryService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
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

        public async Task<IEnumerable<CountryModelResponse>> GetAllCountryAsync(string token)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/Country/allCountry");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

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

        public async Task UpgradeCountryAsync(int id, string token, string value)
        {
            CountryCreateRequest model = new()
            {
                Country = value
            };

            var request = new HttpRequestMessage(HttpMethod.Put, $"/api/Country/{id}")
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
