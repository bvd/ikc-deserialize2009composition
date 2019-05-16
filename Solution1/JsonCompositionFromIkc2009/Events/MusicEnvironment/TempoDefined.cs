using Microsoft.WindowsAzure.Storage.Table;

namespace JsonCompositionFromIkc2009.Events.MusicEnvironment
{
    public class TempoDefined : TableEntity, IMusicEnvironmentEvent
    {
        public string Type
        {
            get
            {
                return this.GetType().AssemblyQualifiedName;
            }
            set
            {
            }
        }
        public float BpmTempo { get; set; }
    }
}