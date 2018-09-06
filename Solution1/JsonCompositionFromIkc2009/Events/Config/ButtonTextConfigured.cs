using Microsoft.WindowsAzure.Storage.Table;

namespace JsonCompositionFromIkc2009.Events.Config
{
    public class ButtonTextConfigured : TableEntity, IConfig
    {
        public ButtonPosition ButtonPosition { get; set; }
        public object ButtonText { get; set; }
    }
}