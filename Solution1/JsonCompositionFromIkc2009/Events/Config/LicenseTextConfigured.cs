namespace JsonCompositionFromIkc2009.Events.Config
{
    public class LicenseTextConfigured : IConfig
    {
        public LicenseTextConfigured()
        {
            this.Type = this.GetType().AssemblyQualifiedName;
        }
        public string Type { get; set; }
        public string Text { get; set; }
    }
}