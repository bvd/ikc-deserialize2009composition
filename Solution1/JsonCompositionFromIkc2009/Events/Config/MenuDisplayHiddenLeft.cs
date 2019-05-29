namespace JsonCompositionFromIkc2009.Events.Config
{
    public class MenuDisplayHiddenLeft : IConfig
    {
        public MenuDisplayHiddenLeft()
        {
            this.Type = this.GetType().AssemblyQualifiedName;
        }
        public string Type { get; set; }
    }
}