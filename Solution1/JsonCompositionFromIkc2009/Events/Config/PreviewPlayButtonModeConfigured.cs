using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace JsonCompositionFromIkc2009.Events.Config
{
    public class PreviewPlayButtonModeConfigured : TableEntity, IConfig
    {
        public string Type
        {
            get
            {
                return this.GetType().AssemblyQualifiedName;
            }
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public PreviewPlayButtonMode Value { get; set; }
    }
}