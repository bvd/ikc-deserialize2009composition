namespace JsonCompositionFromIkc2009.Events.Config
{
    public class LoggerButtonsHidden : IConfig
    {
        public LoggerButtonsHidden()
        {
            this.Type = this.GetType().AssemblyQualifiedName;
        }
        public string Type { get; set; }
    }
}