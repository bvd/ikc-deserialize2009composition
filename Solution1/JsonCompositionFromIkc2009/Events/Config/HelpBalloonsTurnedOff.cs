using Microsoft.WindowsAzure.Storage.Table;

namespace JsonCompositionFromIkc2009.Events.Config
{
    public class HelpBalloonsTurnedOff : TableEntity, IConfig
    {
        public HelpBalloonsTurnedOff()
        {
            this.Type = this.GetType().AssemblyQualifiedName;
        }
        public string Type { get; set; }
    }
}