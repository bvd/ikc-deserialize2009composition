using Microsoft.WindowsAzure.Storage.Table;

namespace JsonCompositionFromIkc2009.Events.Config
{
    public class BackgroundImageConfigured : TableEntity, IConfig
    {
        public string BackgroundImage { get; set; }
    }
}