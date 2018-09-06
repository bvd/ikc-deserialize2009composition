using Microsoft.WindowsAzure.Storage.Table;

namespace JsonCompositionFromIkc2009.Events.Config
{
    public class SloganConfigured : TableEntity, IConfig
    {
        public string Value { get; set; }
    }
}