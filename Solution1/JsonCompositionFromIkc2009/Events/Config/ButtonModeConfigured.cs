﻿using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace JsonCompositionFromIkc2009.Events.Config
{
    public class ButtonModeConfigured : TableEntity, IConfig
    {
        public string Type
        {
            get
            {
                return this.GetType().AssemblyQualifiedName;
            }
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public ButtonPosition ButtonPosition { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public ButtonMode ButtonMode { get; set; }
    }
}