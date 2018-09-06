using Microsoft.WindowsAzure.Storage.Table;

namespace JsonCompositionFromIkc2009.Events.Config
{
    public class TrackHeightChange : TableEntity, IConfig
    {
        public float Value { get; set; }
    }
}