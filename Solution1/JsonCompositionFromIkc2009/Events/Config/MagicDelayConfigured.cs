namespace JsonCompositionFromIkc2009.Events.Config
{
    public class MagicDelayConfigured : IConfig
    {
        public MagicDelayConfigured()
        {
            this.Type = this.GetType().AssemblyQualifiedName;
        }
        public string Type { get; set; }
        public int MagicDelay { get; set; }
    }
}