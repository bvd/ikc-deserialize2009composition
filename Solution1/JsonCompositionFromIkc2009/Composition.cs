using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonCompositionFromIkc2009.TableStorage
{
    public class Composition : TableEntity
    {
        public string Environment { get; set; }
        public string Scroll { get; set; }
        public string Config { get; set; }
        public Composition(
            string composition_identifier, 
            string environment_identifier, 
            string scroll_identifier, 
            string config_identifier)
        {
            this.PartitionKey = composition_identifier;
            this.RowKey = composition_identifier;
            this.Environment = environment_identifier;
            this.Scroll = scroll_identifier;
            this.Config = config_identifier;
        }
    }

    public class Environment : TableEntity
    {
        public Environment(string environment_identifier)
        {
            this.PartitionKey = environment_identifier;
            this.RowKey = environment_identifier;
        }
    }

    public class Scroll : TableEntity
    {
        public Scroll(JsonCompositionFromIkc2009.Scrollitem scroll, string scroll_identifier)
        {
            this.PartitionKey = scroll_identifier;
            this.RowKey = scroll_identifier;
        }

    }

    public class Config : TableEntity
    {
        public Config(string config_identifier, Dictionary<string, string> config)
        {
            this.PartitionKey = config_identifier;
            this.RowKey = config_identifier;
        }
    }
}
