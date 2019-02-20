using Microsoft.WindowsAzure.Storage.Table;

namespace JsonCompositionFromIkc2009.Events.Config
{
    public class TemplateCompositionConfigured : TableEntity, IConfig
    {
        public string Id { get; set; }
    }
}