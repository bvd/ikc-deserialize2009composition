namespace JsonCompositionFromIkc2009.Events.Config
{
    public class TopMarginForSubpartsConfigured : IConfig


    {
        public TopMarginForSubpartsConfigured()
        {
            this.Type = this.GetType().AssemblyQualifiedName;
        }
        public string Type { get; set; }
        public int TopMargin { get; set; }
    }
}