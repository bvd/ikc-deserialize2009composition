namespace JsonCompositionFromIkc2009.Events.Config
{
    public class PlayHeadLineColorConfigured : IConfig
    {
        public PlayHeadLineColorConfigured()
        {
            this.Type = this.GetType().AssemblyQualifiedName;
        }
        public string Type { get; set; }
        public string Color { get; set; }
    }
}