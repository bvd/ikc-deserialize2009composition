using Microsoft.WindowsAzure.Storage.Table;

namespace JsonCompositionFromIkc2009.Events.Config
{
    public class NumberOfTracksConfigured : TableEntity, IConfig
    {
        public NumberOfTracksConfigured()
        {
            this.Type = this.GetType().AssemblyQualifiedName;
        }
        public string Type { get; set; }
        public int NumberOfTracks { get; set; }
    }
}