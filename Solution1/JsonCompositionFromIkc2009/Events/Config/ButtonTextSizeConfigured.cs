using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace JsonCompositionFromIkc2009.Events.Config
{
    public class ButtonTextSizeConfigured : IConfig
    {
        public ButtonTextSizeConfigured()
        {
            this.Type = this.GetType().AssemblyQualifiedName;
        }
        public string Type { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public ButtonPosition ButtonPosition { get; set; }
        public int Size { get; set; }
    }
}