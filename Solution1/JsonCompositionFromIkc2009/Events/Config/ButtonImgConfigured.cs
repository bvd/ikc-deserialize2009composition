using Microsoft.WindowsAzure.Storage.Table;

namespace JsonCompositionFromIkc2009.Events.Config
{
    public class ButtonImgConfigured : TableEntity, IConfig
    {
        public string Img { get; set; }
        public ButtonPosition Posistion { get; set; }
    }
}