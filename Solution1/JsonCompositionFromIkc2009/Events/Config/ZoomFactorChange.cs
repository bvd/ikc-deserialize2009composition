using Microsoft.WindowsAzure.Storage.Table;

namespace JsonCompositionFromIkc2009.Events.Config
{
    public class ZoomFactorChange : TableEntity, IConfig
    {
        public int Denominator { get; set; }
    }
}