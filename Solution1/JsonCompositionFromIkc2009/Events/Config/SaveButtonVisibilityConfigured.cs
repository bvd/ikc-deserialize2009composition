using Microsoft.WindowsAzure.Storage.Table;

namespace JsonCompositionFromIkc2009.Events.Config
{
    public class SaveButtonVisibilityConfigured : TableEntity, IConfig
    {
        public SaveButtonVisibilityConfigured()
        {
            this.Type = this.GetType().AssemblyQualifiedName;
        }
        public string Type { get; set; }
        public bool Visible { get; set; }
    }
}