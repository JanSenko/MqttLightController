using LightPi.Shared;

namespace LightPi.Client.Services.LightsService
{
    public interface ILightsService
    {
        IEnumerable<Light> Lights { get; set; }
        Task GetLights();
        Task<Light> GetSingleLight(int id);
        Task CreateLight(Light LightConfiguration);
        Task UpdateLight(Light LightConfiguration);
        Task DeleteLight(int id);
        Task SetLightState(int id, bool state);
    }
}