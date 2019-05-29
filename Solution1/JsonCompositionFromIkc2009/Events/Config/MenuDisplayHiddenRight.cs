namespace JsonCompositionFromIkc2009.Events.Config
{
    public class MenuDisplayHiddenRight : IConfig
    {
        public MenuDisplayHiddenRight()
        {
            this.Type = this.GetType().AssemblyQualifiedName;
        }
        public string Type { get; set; }
    }
}