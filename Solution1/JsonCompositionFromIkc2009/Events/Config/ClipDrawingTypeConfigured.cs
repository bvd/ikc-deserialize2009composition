using Microsoft.WindowsAzure.Storage.Table;

namespace JsonCompositionFromIkc2009.Events.Config
{
    public class ClipDrawingTypeConfigured : TableEntity, IConfig
    {
        public ClipDrawingType ClipDrawingType { get; set; }
    }
}