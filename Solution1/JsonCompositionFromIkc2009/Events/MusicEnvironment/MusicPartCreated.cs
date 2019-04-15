using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonCompositionFromIkc2009.Events.MusicEnvironment
{
    public class MusicPartCreated: TableEntity, IMusicEnvironmentEvent
    {
        public string Type
        {
            get
            {
                return this.GetType().AssemblyQualifiedName;
            }
        }
        public string id { get; set; }
        public string setId { get; set; }
        public string name { get; set; }
        public int marginX { get; set; }
        public int marginY { get; set; }
        public int width { get; set; }

    }
}
