using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace JsonCompositionFromIkc2009.Events.Config
{
    public class PlayHeadTypeConfigured : IConfig
    {
        public PlayHeadTypeConfigured()
        {
            this.Type = this.GetType().AssemblyQualifiedName;
        }
        public string Type { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public PlayHeadType PlayHeadType { get; set; }
    }
}