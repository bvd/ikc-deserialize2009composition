using Microsoft.WindowsAzure.Storage.Table;

namespace JsonCompositionFromIkc2009.Events.Config
{
    public class MenuDisplayHiddenLeft : TableEntity, IConfig
    {
        public MenuDisplayHiddenLeft()
        {
            this.Type = this.GetType().AssemblyQualifiedName;
        }
        public string Type { get; set; }
    }
}