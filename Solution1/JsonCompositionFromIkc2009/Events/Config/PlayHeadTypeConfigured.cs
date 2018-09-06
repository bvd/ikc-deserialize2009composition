using Microsoft.WindowsAzure.Storage.Table;

namespace JsonCompositionFromIkc2009.Events.Config
{
    public class PlayHeadTypeConfigured : TableEntity, IConfig
    {
        public PlayHeadType PlayHeadType { get; set; }
    }
}