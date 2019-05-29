namespace JsonCompositionFromIkc2009.Events.Config
{
    public class TrackHeightConfigured : IConfig
    {
        public TrackHeightConfigured()
        {
            this.Type = this.GetType().AssemblyQualifiedName;
        }
        public string Type { get; set; }
        public int TrackHeight { get; set; }
    }
}