namespace JsonCompositionFromIkc2009.Events.Config
{
    public class TrackBackgroundHidden : IConfig
    {
        public TrackBackgroundHidden()
        {
            this.Type = this.GetType().AssemblyQualifiedName;
        }
        public string Type { get; set; }
    }
}