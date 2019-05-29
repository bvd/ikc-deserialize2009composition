using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace JsonCompositionFromIkc2009.Events.Config
{
    public class PreviewPlayButtonModeConfigured : IConfig
    {
        public PreviewPlayButtonModeConfigured()
        {
            this.Type = this.GetType().AssemblyQualifiedName;
        }
        public string Type { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public PreviewPlayButtonMode Value { get; set; }
    }
}