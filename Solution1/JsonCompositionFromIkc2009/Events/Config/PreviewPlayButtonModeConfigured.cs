using Microsoft.WindowsAzure.Storage.Table;

namespace JsonCompositionFromIkc2009.Events.Config
{
    public class PreviewPlayButtonModeConfigured : TableEntity, IConfig
    {
        public PreviewPlayButtonMode Value { get; set; }
    }
}