using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonCompositionFromIkc2009.Events.MusicEnvironment
{
    public class MusicClipCreated: TableEntity, IMusicEnvironmentEvent
    {
        public int id { get; set; }
        public int partId { get; set; }
        public int exitpoint { get; set; }
        public int entrypoint { get; set; }
        public string name { get; set; }
        public string tag { get; set; }
        public string icon { get; set; }
        public string ficon { get; set; }
        public string ficonroll { get; set; }
        public int order { get; set; }
        public string width { get; set; }
        public string height { get; set; }
        public string color { get; set; }
    }
}
