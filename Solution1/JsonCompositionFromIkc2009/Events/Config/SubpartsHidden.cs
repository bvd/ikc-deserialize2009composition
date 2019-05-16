using Microsoft.WindowsAzure.Storage.Table;

namespace JsonCompositionFromIkc2009.Events.Config
{
    public class SubpartsHidden : TableEntity, IConfig
    {
        public SubpartsHidden()
        {
            this.Type = this.GetType().AssemblyQualifiedName;
        }
        public string Type { get; set; }
        public string SubPartsCommaSeparated { get; set; }
    }
}