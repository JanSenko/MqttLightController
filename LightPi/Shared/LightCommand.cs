namespace LightPi.Shared
{
    public abstract class BaseCommand
    {
        public string TargetTopic { get; set; }
        public Guid CommandId { get; set; }
    }
}
