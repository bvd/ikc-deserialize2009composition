using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonCompositionFromIkc2009.Events
{
    public class SerializedTableEntity : TableEntity
    {
        public string json { get; set; }
    }
}
