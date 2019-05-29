namespace JsonCompositionFromIkc2009.Events.Config
{
    public class SloganConfigured : IConfig
    {
        public SloganConfigured()
        {
            this.Type = this.GetType().AssemblyQualifiedName;
        }
        public string Type { get; set; }
        public string Value { get; set; }
    }
}