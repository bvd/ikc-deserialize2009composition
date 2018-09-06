using Microsoft.WindowsAzure.Storage.Table;

namespace JsonCompositionFromIkc2009.Events.Config
{
    public class TracksBackgroundConfigured : TableEntity, IConfig
    {
        public string BackgroundImage { get; set; }
    }
}