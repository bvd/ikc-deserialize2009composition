using Microsoft.WindowsAzure.Storage.Table;

namespace JsonCompositionFromIkc2009.Events.Config
{
    public class ButtonTextSizeConfigured : TableEntity, IConfig
    {
        public ButtonPosition ButtonPosition { get; set; }
        public int Size { get; set; }
    }
}