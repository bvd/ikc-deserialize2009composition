namespace JsonCompositionFromIkc2009.Events.Config
{
    public class NumberOfTracksConfigured : IConfig
    {
        public NumberOfTracksConfigured()
        {
            this.Type = this.GetType().AssemblyQualifiedName;
        }
        public string Type { get; set; }
        public int NumberOfTracks { get; set; }
    }
}