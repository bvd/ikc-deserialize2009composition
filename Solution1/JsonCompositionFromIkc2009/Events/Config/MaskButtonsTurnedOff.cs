using Microsoft.WindowsAzure.Storage.Table;

namespace JsonCompositionFromIkc2009.Events.Config
{
    public class MaskButtonsTurnedOff : TableEntity, IConfig
    {
        public MaskButtonsTurnedOff()
        {
            this.Type = this.GetType().AssemblyQualifiedName;
        }
        public string Type { get; set; }
        public bool Off { get; set; }
    }
}