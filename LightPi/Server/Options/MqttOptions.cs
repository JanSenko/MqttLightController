namespace LightPi.Server.Options
{
    public class MqttOptions
    {
        public const string ConfigSectionName = "Mqtt";

        public string BrokerAddress { get; set; } = String.Empty;
    }
}
