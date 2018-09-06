using Microsoft.WindowsAzure.Storage.Table;

namespace JsonCompositionFromIkc2009.Events.Config
{
    public class SubpartsHidden : TableEntity, IConfig
    {
        public string SubPartsCommaSeparated { get; set; }
    }
}