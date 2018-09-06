﻿using Microsoft.WindowsAzure.Storage.Table;

namespace JsonCompositionFromIkc2009.Events.MusicEnvironment
{
    public class TempoDefined : TableEntity, IMusicEnvironmentEvent
    {
        public float BpmTempo { get; set; }
    }
}