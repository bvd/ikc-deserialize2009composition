namespace JsonCompositionFromIkc2009.Events.Config
{
    public class SubpartsHidden : IConfig
    {
        public SubpartsHidden()
        {
            this.Type = this.GetType().AssemblyQualifiedName;
        }
        public string Type { get; set; }
        public string SubPartsCommaSeparated { get; set; }
    }
}