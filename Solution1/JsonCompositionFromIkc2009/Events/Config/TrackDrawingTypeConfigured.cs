﻿using Microsoft.WindowsAzure.Storage.Table;

namespace JsonCompositionFromIkc2009.Events.Config
{
    public class TrackDrawingTypeConfigured : TableEntity, IConfig
    {
        public TrackDrawingType TrackDrawingType { get; set; }
    }
}