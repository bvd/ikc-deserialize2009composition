using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonCompositionFromIkc2009.Events.Composition
{
    public class ClearCompositionEvent : TableEntity, IComposition
    {
        public ClearCompositionEvent()
        {
            this.Type = this.GetType().AssemblyQualifiedName;
        }

        public string Type { get; set; }
    }
}
