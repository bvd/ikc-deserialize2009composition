namespace JsonCompositionFromIkc2009.Events.Config
{
    public class SloganFontConfigured : IConfig
    {
        public SloganFontConfigured()
        {
            this.Type = this.GetType().AssemblyQualifiedName;
        }
        public string Type { get; set; }
        public string Font { get; set; }
    }
}