using Microsoft.WindowsAzure.Storage.Table;

namespace JsonCompositionFromIkc2009.Events.Config
{
    public class SloganFontSizeConfigured : TableEntity, IConfig
    {
        public int Heiht { get; set; }
    }
}