using Microsoft.WindowsAzure.Storage.Table;

namespace JsonCompositionFromIkc2009.Events.Config
{
    public class TopMarginForSubpartsConfigured : TableEntity, IConfig

         
    {
        public string Type
        {
            get
            {
                return this.GetType().AssemblyQualifiedName;
            }
        }
        public int TopMargin { get; set; }
    }
}