using Microsoft.WindowsAzure.Storage.Table;

namespace JsonCompositionFromIkc2009.Events.Config
{
    public class SaveButtonVisibilityConfigured : TableEntity, IConfig
    {
        public bool Visible { get; set; }
    }
}