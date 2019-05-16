using Microsoft.WindowsAzure.Storage.Table;

namespace JsonCompositionFromIkc2009.Events.Config
{
    public class BackgroundImageConfigured : TableEntity, IConfig
    {
        public BackgroundImageConfigured()
        {
            this.Type = this.GetType().AssemblyQualifiedName;
        }
        public string Type { get; set; }
        public string BackgroundImage { get; set; }
    }
}