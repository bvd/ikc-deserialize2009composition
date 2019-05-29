namespace JsonCompositionFromIkc2009.Events.Config
{
    public class TracksCentered : IConfig
    {
        public TracksCentered()
        {
            this.Type = this.GetType().AssemblyQualifiedName;
        }
        public string Type { get; set; }
    }
}