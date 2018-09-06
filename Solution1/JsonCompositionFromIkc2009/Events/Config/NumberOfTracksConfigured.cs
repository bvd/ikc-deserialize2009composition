using Microsoft.WindowsAzure.Storage.Table;

namespace JsonCompositionFromIkc2009.Events.Config
{
    public class NumberOfTracksConfigured : TableEntity, IConfig
    {
        public int NumberOfTracks { get; set; }
    }
}