using Microsoft.WindowsAzure.Storage.Table;

namespace JsonCompositionFromIkc2009.Events.Config
{
    public class ButtonColorConfigured : TableEntity, IConfig
    {
        public ButtonPosition ButtonPosition { get; set; }
        public int Order { get; set; }
        public string ButtonColor { get; set; }
    }
}