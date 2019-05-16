using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace JsonCompositionFromIkc2009.Events.Config
{
    public class ButtonBehaviorConfigured : TableEntity, IConfig
    {
        public ButtonBehaviorConfigured()
        {
            this.Type = this.GetType().AssemblyQualifiedName;
        }
        public string Type { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public ButtonPosition ButtonPosition { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public IkcNotification ButtonNote { get; set; }
    }
}