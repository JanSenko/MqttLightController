using LightPi.Shared;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace LightPi.Client.Services.LightsService
{
    public class LightsService : ILightsService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public LightsService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }

        public IEnumerable<Light> Lights { get; set; } = new List<Light>();

        public async Task CreateLight(Light LightConfiguration)
        {
            var result = await _http.PostAsJsonAsync("api/lights", LightConfiguration);
            await FetchLightConfigurations(result);
        }

        public async Task DeleteLight(int id)
        {
            var result = await _http.DeleteAsync($"api/lights/{id}");
            await FetchLightConfigurations(result);
        }

        public async Task GetLights()
        {
            var result = await _http.GetFromJsonAsync<IEnumerable<Light>>("api/lights");
            if (result != null)
                Lights = result;
        }

        public async Task<Light> GetSingleLight(int id)
        {
            var result = await _http.GetFromJsonAsync<Light>($"api/lights/{id}");
            if (result != null)
                return result;
            throw new Exception("Light not found!");
        }

        public async Task UpdateLight(Light LightConfiguration)
        {
            var result = await _http.PutAsJsonAsync($"api/lights/{LightConfiguration.LightID}", LightConfiguration);
            await FetchLightConfigurations(result);
        }

        private async Task FetchLightConfigurations(HttpResponseMessage result)
        {
            await GetLights();
            _navigationManager.NavigateTo("Lights");
        }

        public async Task SetLightState(int id, bool state)
        {
            await _http.PostAsync($"api/lightcommand/{id}/lightState/{state}", null);
        }
    }

}
