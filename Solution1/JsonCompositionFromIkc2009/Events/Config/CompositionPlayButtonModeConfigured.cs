﻿using Microsoft.WindowsAzure.Storage.Table;

namespace JsonCompositionFromIkc2009.Events.Config
{
    public class CompositionPlayButtonModeConfigured : TableEntity, IConfig
    {
        public CompositionPlayButtonMode Value { get; set; }
    }
}