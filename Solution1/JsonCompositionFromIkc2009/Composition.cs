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
        public JsonCompositionFromIkc2009.Composition Item { get; set; }
        public Composition(
            JsonCompositionFromIkc2009.Composition composition, 
            string environment_identifier, 
            string scroll_identifier, 
            string config_identifier)
        {
            this.PartitionKey = composition.id.ToString();
            this.RowKey = composition.id.ToString();
            this.Item = composition;
        }
    }

    public class Environment : TableEntity
    {
        public string EnvironmentIdentifier { get; set; }
        public JsonCompositionFromIkc2009.Environment Item { get; set; }
        public Environment(JsonCompositionFromIkc2009.Environment environment, string environment_identifier)
        {
            this.PartitionKey = environment_identifier;
            this.RowKey = environment_identifier;
            this.Item = environment;
            this.EnvironmentIdentifier = environment_identifier;
        }
    }

    public class Scroll : TableEntity
    {
        public string ScrollIdentifier { get; set; }
        public JsonCompositionFromIkc2009.Scrollitem Item { get; set; }
        public Scroll(JsonCompositionFromIkc2009.Scrollitem scroll, string scroll_identifier)
        {
            this.PartitionKey = scroll_identifier;
            this.RowKey = scroll_identifier;
            this.Item = scroll;
            this.ScrollIdentifier = scroll_identifier;
        }

    }

    public class Config : TableEntity
    {
        public string ConfigIdentifier { get; set; }
        public Dictionary<string, string> Item { get; set; }
        public Config(string config_identifier, Dictionary<string, string> config)
        {
            this.PartitionKey = config_identifier;
            this.RowKey = config_identifier;
            this.ConfigIdentifier = config_identifier;
            this.Item = config;
        }
    }
}
