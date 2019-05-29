namespace JsonCompositionFromIkc2009.Events.Config
{
    public class AudioTipsConfigured : IConfig
    {
        public AudioTipsConfigured()
        {
            this.Type = this.GetType().AssemblyQualifiedName;
        }
        public string Type { get; set; }
        public string AudioTipsCommaSeperated { get; set; }
    }
}