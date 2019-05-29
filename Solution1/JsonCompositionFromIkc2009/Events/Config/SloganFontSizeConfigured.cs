namespace JsonCompositionFromIkc2009.Events.Config
{
    public class SloganFontSizeConfigured : IConfig
    {
        public SloganFontSizeConfigured()
        {
            this.Type = this.GetType().AssemblyQualifiedName;
        }
        public string Type { get; set; }
        public int FontSize { get; set; }
    }
}