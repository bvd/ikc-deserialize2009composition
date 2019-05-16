using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace JsonCompositionFromIkc2009.Events.Config
{
    public class TrackDrawingTypeConfigured : TableEntity, IConfig
    {
        public TrackDrawingTypeConfigured()
        {
            this.Type = this.GetType().AssemblyQualifiedName;
        }
        public string Type { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public TrackDrawingType TrackDrawingType { get; set; }
    }
}