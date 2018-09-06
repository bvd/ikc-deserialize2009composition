using Microsoft.WindowsAzure.Storage.Table;

namespace JsonCompositionFromIkc2009.Events.Config
{
    public class LoggerButtonsHidden : TableEntity, IConfig
    {
        public bool Show { get; set; }
    }
}