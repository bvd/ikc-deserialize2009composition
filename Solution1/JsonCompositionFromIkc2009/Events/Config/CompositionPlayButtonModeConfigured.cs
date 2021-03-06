﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace JsonCompositionFromIkc2009.Events.Config
{
    public class CompositionPlayButtonModeConfigured : IConfig
    {
        public CompositionPlayButtonModeConfigured()
        {
            this.Type = this.GetType().AssemblyQualifiedName;
        }
        public string Type { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public CompositionPlayButtonMode Value { get; set; }
    }
}