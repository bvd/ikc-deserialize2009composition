namespace JsonCompositionFromIkc2009.Events.Config
{
    public class QuantizeGridChange : IConfig
    {
        public QuantizeGridChange()
        {
            this.Type = this.GetType().AssemblyQualifiedName;
        }
        public string Type { get; set; }
        public float Numerator { get; set; }
        public float Denominator { get; set; }
    }
}