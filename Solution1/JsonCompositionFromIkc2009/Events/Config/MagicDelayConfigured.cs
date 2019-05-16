using Microsoft.WindowsAzure.Storage.Table;

namespace JsonCompositionFromIkc2009.Events.Config
{
    public class MagicDelayConfigured : TableEntity, IConfig
    {
        public MagicDelayConfigured()
        {
            this.Type = this.GetType().AssemblyQualifiedName;
        }
        public string Type { get; set; }
        public int MagicDelay { get; set; }
    }
}