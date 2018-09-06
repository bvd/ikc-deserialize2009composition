using Microsoft.WindowsAzure.Storage.Table;

namespace JsonCompositionFromIkc2009.Events.Config
{
    public class PlayHeadLineColorConfigured : TableEntity, IConfig
    {
        public string Color { get; set; }
    }
}