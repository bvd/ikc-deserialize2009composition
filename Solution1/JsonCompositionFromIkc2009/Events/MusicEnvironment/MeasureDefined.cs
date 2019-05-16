using Microsoft.WindowsAzure.Storage.Table;

namespace JsonCompositionFromIkc2009.Events.MusicEnvironment
{
    public class MeasureDefined : TableEntity, IMusicEnvironmentEvent
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