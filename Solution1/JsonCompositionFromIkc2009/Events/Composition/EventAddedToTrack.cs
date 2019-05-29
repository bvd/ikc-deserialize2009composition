namespace JsonCompositionFromIkc2009.Events.Composition
{
    public class EventAddedToTrack : IComposition
    {
        public EventAddedToTrack()
        {
            this.Type = this.GetType().AssemblyQualifiedName;
        }
        public string Type { get; set; }
        public int Track { get; set; }
        public int Index { get; set; }
        public int Start { get; set; }
        public int End { get; set; }
        public int Total { get; set; }
        public int Offset { get; set; }
        public int SourceId { get; set; }
    }
}