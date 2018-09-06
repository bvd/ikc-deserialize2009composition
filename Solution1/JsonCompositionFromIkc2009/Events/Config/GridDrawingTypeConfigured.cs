using Microsoft.WindowsAzure.Storage.Table;

namespace JsonCompositionFromIkc2009.Events.Config
{
    internal class GridDrawingTypeConfigured : TableEntity, IConfig
    {
        public GridDrawingType GridDrawingType { get; set; }
    }
}