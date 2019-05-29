namespace JsonCompositionFromIkc2009.Events.MusicEnvironment
{
    public class MusicPartCreated : IMusicEnvironmentEvent
    {
        public MusicPartCreated()
        {
            this.Type = this.GetType().AssemblyQualifiedName;
        }
        public string Type { get; set; }
        public string id { get; set; }
        public string setId { get; set; }
        public string name { get; set; }
        public int marginX { get; set; }
        public int marginY { get; set; }
        public int width { get; set; }

    }
}
