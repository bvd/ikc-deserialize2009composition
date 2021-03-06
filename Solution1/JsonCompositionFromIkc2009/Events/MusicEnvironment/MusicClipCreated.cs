﻿namespace JsonCompositionFromIkc2009.Events.MusicEnvironment
{
    public class MusicClipCreated : IMusicEnvironmentEvent
    {
        public MusicClipCreated()
        {
            this.Type = this.GetType().AssemblyQualifiedName;
        }
        public string Type { get; set; }
        public string id { get; set; }
        public string partId { get; set; }
        public int exitpoint { get; set; }
        public int entrypoint { get; set; }
        public string name { get; set; }
        public string tag { get; set; }
        public string icon { get; set; }
        public string ficon { get; set; }
        public string ficonroll { get; set; }
        public string iconAdjustWidth { get; set; }
        public string iconAdjustHeight { get; set; }
        public string color { get; set; }
    }
}
