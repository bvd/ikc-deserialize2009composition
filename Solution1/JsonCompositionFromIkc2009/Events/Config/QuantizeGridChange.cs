using Microsoft.WindowsAzure.Storage.Table;

namespace JsonCompositionFromIkc2009.Events.Config
{
    public class QuantizeGridChange : TableEntity, IConfig
    {
        public float Numerator { get; set; }
        public float Denominator { get; set; }
    }
}