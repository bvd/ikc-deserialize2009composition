using Microsoft.WindowsAzure.Storage.Table;

namespace JsonCompositionFromIkc2009.Events.Config
{
    public class HelpBalloonsTurnedOff : TableEntity, IConfig
    {
        public bool Value { get; set; }
    }
}