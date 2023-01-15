using LightPi.Server.Options;
using LightPi.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MQTTnet.Client;
using MQTTnet;
using LightPi.Data;

namespace LightPi.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LightCommandController : ControllerBase
    {
        private readonly MqttOptions _options;
        private readonly MqttFactory _mqttFactory;
        private readonly MqttClientOptions _mqttClientOptions;
        private readonly LightsContext _lightsContexts;

        public LightCommandController(IOptions<MqttOptions> options, LightsContext lightsContexts)
        {
            _options = options.Value;
            _mqttFactory = new MqttFactory();
            _mqttClientOptions = new MqttClientOptionsBuilder().WithTcpServer(_options.BrokerAddress).Build();
            _lightsContexts = lightsContexts;
        }

        [HttpPost("{lightID}/lightState/{targetState}")]
        public async Task<IActionResult> SetLightState(int lightId, bool targetState)
        {
            Light? found = await _lightsContexts.Lights.FindAsync(lightId);
            if (found == null)
            {
                return NotFound();
            }

            return await SetLightState(new SetLightStateCommand()
            {
                State= targetState,
                TargetTopic= found.Route,
                CommandId = Guid.NewGuid()
            });
        }

        [HttpPost("lightState")]
        public async Task<IActionResult> SetLightState([FromBody] SetLightStateCommand command)
        {
            //TODO add usefull error handling
            using (var mqttClient = _mqttFactory.CreateMqttClient())
            {
                await mqttClient.ConnectAsync(_mqttClientOptions, CancellationToken.None);

                var applicationMessage = new MqttApplicationMessageBuilder()
                    .WithTopic($"{command.TargetTopic}/LightState")
                    .WithPayload(command.State ? "on" : "off")
                    .Build();

                await mqttClient.PublishAsync(applicationMessage, CancellationToken.None);

                await mqttClient.DisconnectAsync();
            }
            //TODO await a response message via mqtt - but for know just fire and forget
            return Ok();
        }
    }
}
