using Microsoft.WindowsAzure.Storage.Table;

namespace JsonCompositionFromIkc2009.Events.Config
{
    public class AudioTipsConfigured : TableEntity, IConfig
    {
        public AudioTipsConfigured()
        {
            this.Type = this.GetType().AssemblyQualifiedName;
        }
        public string Type { get; set; }
        public string AudioTipsCommaSeperated { get; set; }
    }
}