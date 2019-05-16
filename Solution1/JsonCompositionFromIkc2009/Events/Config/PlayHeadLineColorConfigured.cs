using Microsoft.WindowsAzure.Storage.Table;

namespace JsonCompositionFromIkc2009.Events.Config
{
    public class PlayHeadLineColorConfigured : TableEntity, IConfig
    {
        public PlayHeadLineColorConfigured()
        {
            this.Type = this.GetType().AssemblyQualifiedName;
        }
        public string Type { get; set; }
        public string Color { get; set; }
    }
}