﻿using Microsoft.WindowsAzure.Storage.Table;

namespace JsonCompositionFromIkc2009.Events.Config
{
    public class SloganFontSizeConfigured : TableEntity, IConfig
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
        public int FontSize { get; set; }
    }
}