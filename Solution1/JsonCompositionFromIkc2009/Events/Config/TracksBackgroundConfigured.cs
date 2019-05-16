using Microsoft.WindowsAzure.Storage.Table;

namespace JsonCompositionFromIkc2009.Events.Config
{
    public class TracksBackgroundConfigured : TableEntity, IConfig
    {
        public TracksBackgroundConfigured()
        {
            this.Type = this.GetType().AssemblyQualifiedName;
        }
        public string Type { get; set; }
        public string BackgroundImage { get; set; }
    }
}