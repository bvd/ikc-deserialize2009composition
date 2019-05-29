using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace JsonCompositionFromIkc2009.Events.Config
{
    public class ButtonColorConfigured : IConfig
    {
        public ButtonColorConfigured()
        {
            this.Type = this.GetType().AssemblyQualifiedName;
        }
        public string Type { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public ButtonPosition ButtonPosition { get; set; }
        public int Order { get; set; }
        public string ButtonColor { get; set; }
    }
}