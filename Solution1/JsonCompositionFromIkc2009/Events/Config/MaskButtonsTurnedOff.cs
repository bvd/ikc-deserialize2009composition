using Microsoft.WindowsAzure.Storage.Table;

namespace JsonCompositionFromIkc2009.Events.Config
{
    public class MaskButtonsTurnedOff : TableEntity, IConfig
    {
        public bool Off { get; set; }
    }
}