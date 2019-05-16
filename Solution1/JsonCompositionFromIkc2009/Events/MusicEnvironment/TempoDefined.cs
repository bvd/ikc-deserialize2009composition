using Microsoft.WindowsAzure.Storage.Table;

namespace JsonCompositionFromIkc2009.Events.MusicEnvironment
{
    public class TempoDefined : TableEntity, IMusicEnvironmentEvent
    {
        public TempoDefined()
        {
            this.Type = this.GetType().AssemblyQualifiedName;
        }
        public string Type { get; set; }
        public float BpmTempo { get; set; }
    }
}