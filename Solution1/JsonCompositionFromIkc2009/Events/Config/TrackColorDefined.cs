namespace JsonCompositionFromIkc2009.Events.Config
{
    public class TrackColorDefined : IConfig
    {
        public TrackColorDefined()
        {
            this.Type = this.GetType().AssemblyQualifiedName;
        }
        public string Type { get; set; }
        public string Value { get; set; }
    }
}