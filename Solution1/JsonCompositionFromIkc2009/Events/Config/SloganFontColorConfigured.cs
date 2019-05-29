namespace JsonCompositionFromIkc2009.Events.Config
{
    public class SloganFontColorConfigured : IConfig
    {
        public SloganFontColorConfigured()
        {
            this.Type = this.GetType().AssemblyQualifiedName;
        }
        public string Type { get; set; }
        public string Color { get; set; }
    }
}