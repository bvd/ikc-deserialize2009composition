using Microsoft.WindowsAzure.Storage.Table;

namespace JsonCompositionFromIkc2009.Events.Config
{
    public class TrackColorDefined : TableEntity, IConfig
    {
        public string Value { get; set; }
    }
}