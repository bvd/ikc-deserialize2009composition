namespace JsonCompositionFromIkc2009.Events.MusicEnvironment
{
    public class TempoDefined : IMusicEnvironmentEvent
    {
        public TempoDefined()
        {
            this.Type = this.GetType().AssemblyQualifiedName;
        }
        public string Type { get; set; }
        public float BpmTempo { get; set; }
    }
}