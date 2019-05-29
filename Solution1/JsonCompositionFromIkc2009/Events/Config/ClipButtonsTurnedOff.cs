namespace JsonCompositionFromIkc2009.Events.Config
{
    public class ClipButtonsTurnedOff : IConfig
    {
        public ClipButtonsTurnedOff()
        {
            this.Type = this.GetType().AssemblyQualifiedName;
        }
        public string Type { get; set; }
    }
}