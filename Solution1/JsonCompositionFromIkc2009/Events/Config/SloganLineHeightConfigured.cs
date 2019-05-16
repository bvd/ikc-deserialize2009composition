using Microsoft.WindowsAzure.Storage.Table;

namespace JsonCompositionFromIkc2009.Events.Config
{
    public class SloganLineHeightConfigured : TableEntity, IConfig
    {
        public SloganLineHeightConfigured()
        {
            this.Type = this.GetType().AssemblyQualifiedName;
        }
        public string Type { get; set; }
        public int Height { get; set; }
    }
}