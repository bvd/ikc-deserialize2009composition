namespace JsonCompositionFromIkc2009.Events.Config
{
    public class TrackHeightChange : IConfig
    {
        public TrackHeightChange()
        {
            this.Type = this.GetType().AssemblyQualifiedName;
        }
        public string Type { get; set; }
        public float Value { get; set; }
    }
}