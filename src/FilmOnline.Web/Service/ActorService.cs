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
    /// <inheritdoc cref="IActorService"/>
    public class ActorService : IActorService
    {
        private readonly HttpClient _httpClient;

        public ActorService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task AddActorAsync(ActorCreateRequest model, string token)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/Actor/addActor")
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

        public async Task DeleteActorAsync(int id, string token)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, $"/api/Actor/{id}");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            using var response = await _httpClient.SendAsync(request);

            // throw exception on error response
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadFromJsonAsync<Dictionary<string, string>>();
                throw new Exception(error["message"]);
            }
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

        public async Task UpgradeActorAsync(int id, string token, ActorCreateRequest model)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, $"/api/Actor/{id}")
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
