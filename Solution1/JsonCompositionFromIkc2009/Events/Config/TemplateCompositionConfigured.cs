namespace JsonCompositionFromIkc2009.Events.Config
{
    public class TemplateCompositionConfigured : IConfig
    {
        public TemplateCompositionConfigured()
        {
            this.Type = this.GetType().AssemblyQualifiedName;
        }
        public string Type { get; set; }
        public string Id { get; set; }
    }
}