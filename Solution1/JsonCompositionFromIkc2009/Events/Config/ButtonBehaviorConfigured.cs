using Microsoft.WindowsAzure.Storage.Table;

namespace JsonCompositionFromIkc2009.Events.Config
{
    public class ButtonBehaviorConfigured : TableEntity, IConfig
    {
        public ButtonPosition ButtonPosition { get; set; }
        public IkcNotification ButtonNote { get; set; }
    }
}