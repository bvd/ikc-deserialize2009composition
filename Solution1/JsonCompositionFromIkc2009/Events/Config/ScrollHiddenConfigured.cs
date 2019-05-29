namespace JsonCompositionFromIkc2009.Events.Config
{
    public class ScrollHiddenConfigured : IConfig
    {
        public ScrollHiddenConfigured()
        {
            this.Type = this.GetType().AssemblyQualifiedName;
        }
        public string Type { get; set; }
    }
}