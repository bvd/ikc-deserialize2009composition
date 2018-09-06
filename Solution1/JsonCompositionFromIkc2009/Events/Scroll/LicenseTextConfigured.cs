using Microsoft.WindowsAzure.Storage.Table;

namespace JsonCompositionFromIkc2009.Events.Config
{
    public class LicenseTextConfigured : TableEntity, IConfig
    {
        public string Text { get; set; }
    }
}