﻿using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace JsonCompositionFromIkc2009.Events.Config
{
    public class CompositionPlayButtonModeConfigured : TableEntity, IConfig
    {
        public string Type
        {
            get
            {
                return this.GetType().AssemblyQualifiedName;
            }
            set
            {
            }
        }
        [JsonConverter(typeof(StringEnumConverter))]
        public CompositionPlayButtonMode Value { get; set; }
    }
}