using Microsoft.WindowsAzure.Storage.Table;

namespace JsonCompositionFromIkc2009.Events.Config
{
    public class ButtonModeConfigured : TableEntity, IConfig
    {
        public ButtonPosition ButtonPosition { get; set; }
        public ButtonMode ButtonNote { get; set; }
    }
}