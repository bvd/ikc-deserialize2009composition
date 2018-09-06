using Microsoft.WindowsAzure.Storage.Table;

namespace JsonCompositionFromIkc2009.Events.MusicEnvironment
{
    public class MusicSetCreated : TableEntity, IMusicEnvironmentEvent
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string background { get; set; }
        public string type { get; set; }
    }
}