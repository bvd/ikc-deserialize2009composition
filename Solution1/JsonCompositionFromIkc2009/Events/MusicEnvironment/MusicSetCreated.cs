namespace JsonCompositionFromIkc2009.Events.MusicEnvironment
{
    public class MusicSetCreated : IMusicEnvironmentEvent
    {
        public MusicSetCreated()
        {
            this.Type = this.GetType().AssemblyQualifiedName;
        }
        public string Type { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string background { get; set; }
        public string type { get; set; }
    }
}