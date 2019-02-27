using Microsoft.WindowsAzure.Storage.Table;

namespace JsonCompositionFromIkc2009.Events.Config
{
    public class GridDrawingTypeConfigured : TableEntity, IConfig
    {
        public GridDrawingType GridDrawingType { get; set; }
    }
}