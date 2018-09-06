using Microsoft.WindowsAzure.Storage.Table;

namespace JsonCompositionFromIkc2009.Events.Config
{
    public class TrackHeightConfigured : TableEntity, IConfig
    {
        public int TrackHeight { get; set; }
    }
}