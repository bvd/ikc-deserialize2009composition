namespace JsonCompositionFromIkc2009.Events.Config
{
    public class SloganLineHeightConfigured : IConfig
    {
        public SloganLineHeightConfigured()
        {
            this.Type = this.GetType().AssemblyQualifiedName;
        }
        public string Type { get; set; }
        public int Height { get; set; }
    }
}