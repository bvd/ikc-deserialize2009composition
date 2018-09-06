using Microsoft.WindowsAzure.Storage.Table;

namespace JsonCompositionFromIkc2009.Events.Config
{
    public class ButtonClassConfigured : TableEntity, IConfig
    {
        public ButtonPosition ButtonPosition { get; set; }
        public ButtonClass ButtonClass { get; set; }
    }
}