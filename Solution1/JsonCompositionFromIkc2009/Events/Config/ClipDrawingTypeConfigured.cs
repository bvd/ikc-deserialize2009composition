﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace JsonCompositionFromIkc2009.Events.Config
{
    public class ClipDrawingTypeConfigured : IConfig
    {
        public ClipDrawingTypeConfigured()
        {
            this.Type = this.GetType().AssemblyQualifiedName;
        }
        public string Type { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public ClipDrawingType ClipDrawingType { get; set; }
    }
}