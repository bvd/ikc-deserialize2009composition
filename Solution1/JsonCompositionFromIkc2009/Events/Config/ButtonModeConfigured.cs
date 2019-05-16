using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace JsonCompositionFromIkc2009.Events.Config
{
    public class ButtonModeConfigured : TableEntity, IConfig
    {
        public ButtonModeConfigured()
        {
            this.Type = this.GetType().AssemblyQualifiedName;
        }
        public string Type { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public ButtonPosition ButtonPosition { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public ButtonMode ButtonMode { get; set; }
    }
}