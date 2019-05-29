using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace JsonCompositionFromIkc2009.Events.Config
{
    public class ButtonImgConfigured : IConfig
    {
        public ButtonImgConfigured()
        {
            this.Type = this.GetType().AssemblyQualifiedName;
        }
        public string Type { get; set; }
        public string Img { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public ButtonPosition ButtonPosition { get; set; }
    }
}