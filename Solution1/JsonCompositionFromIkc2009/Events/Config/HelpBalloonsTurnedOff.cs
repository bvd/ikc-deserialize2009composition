namespace JsonCompositionFromIkc2009.Events.Config
{
    public class HelpBalloonsTurnedOff : IConfig
    {
        public HelpBalloonsTurnedOff()
        {
            this.Type = this.GetType().AssemblyQualifiedName;
        }
        public string Type { get; set; }
    }
}