namespace JsonCompositionFromIkc2009.Events.MusicEnvironment
{
    public class MeasureDefined : IMusicEnvironmentEvent
    {
        public MeasureDefined()
        {
            this.Type = this.GetType().AssemblyQualifiedName;
        }
        public string Type { get; set; }
        public int Numerator { get; set; }
        public int Denominator { get; set; }
    }
}