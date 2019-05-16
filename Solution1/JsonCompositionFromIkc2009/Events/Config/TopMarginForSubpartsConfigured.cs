using Microsoft.WindowsAzure.Storage.Table;

namespace JsonCompositionFromIkc2009.Events.Config
{
    public class TopMarginForSubpartsConfigured : TableEntity, IConfig


    {
        public TopMarginForSubpartsConfigured()
        {
            this.Type = this.GetType().AssemblyQualifiedName;
        }
        public string Type { get; set; }
        public int TopMargin { get; set; }
    }
}