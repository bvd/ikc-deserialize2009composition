using Microsoft.WindowsAzure.Storage.Table;

namespace JsonCompositionFromIkc2009.Events.MusicEnvironment
{
    public class MeasureDefined : TableEntity, IMusicEnvironmentEvent
    {
        public int Numerator { get; set; }
        public int Denominator { get; set; }
    }
}