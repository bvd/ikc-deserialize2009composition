namespace JsonCompositionFromIkc2009.Events.Config
{
    public class MaskButtonsTurnedOff : IConfig
    {
        public MaskButtonsTurnedOff()
        {
            this.Type = this.GetType().AssemblyQualifiedName;
        }
        public string Type { get; set; }
        public bool Off { get; set; }
    }
}