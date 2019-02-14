using Microsoft.WindowsAzure.Storage.Table;

namespace JsonCompositionFromIkc2009.Events.Config
{
    // zoom factor change is the width of the screen in measures
    public class ZoomFactorChange : TableEntity, IConfig
    {
        public int Denominator { get; set; }
    }
}