using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace JsonCompositionFromIkc2009.Events.Config
{
    public class GridDrawingTypeConfigured : IConfig
    {
        public GridDrawingTypeConfigured()
        {
            this.Type = this.GetType().AssemblyQualifiedName;
        }
        public string Type { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public GridDrawingType GridDrawingType { get; set; }
    }
}