namespace JsonCompositionFromIkc2009.Events.Config
{
    public class TracksBackgroundConfigured : IConfig
    {
        public TracksBackgroundConfigured()
        {
            this.Type = this.GetType().AssemblyQualifiedName;
        }
        public string Type { get; set; }
        public string BackgroundImage { get; set; }
    }
}