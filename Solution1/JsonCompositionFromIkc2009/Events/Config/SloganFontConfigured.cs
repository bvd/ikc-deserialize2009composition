using Microsoft.WindowsAzure.Storage.Table;

namespace JsonCompositionFromIkc2009.Events.Config
{
    public class SloganFontConfigured : TableEntity, IConfig
    {
        public string Font { get; set; }
    }
}