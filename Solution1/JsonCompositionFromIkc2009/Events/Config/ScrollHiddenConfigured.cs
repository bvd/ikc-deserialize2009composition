﻿using Microsoft.WindowsAzure.Storage.Table;

namespace JsonCompositionFromIkc2009.Events.Config
{
    public class ScrollHiddenConfigured : TableEntity, IConfig
    {
        public string Type
        {
            get
            {
                return this.GetType().AssemblyQualifiedName;
            }
        }
    }
}