using Microsoft.WindowsAzure.Storage.Table;

namespace JsonCompositionFromIkc2009.Events.Config
{
    public class AudioTipsConfigured : TableEntity, IConfig
    {
        public string AudioTipsCommaSeperated { get; set; }
    }
}