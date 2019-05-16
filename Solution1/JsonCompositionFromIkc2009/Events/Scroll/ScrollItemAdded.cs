using Microsoft.WindowsAzure.Storage.Table;

namespace JsonCompositionFromIkc2009.Events.Scroll
{
    public class ScrollItemAdded : TableEntity, IScroll
    {
        public string Type
        {
            get
            {
                return this.GetType().AssemblyQualifiedName;
            }
            set
            {
            }
        }
        public string Name { get; set; }
        public int Index { get; set; }
        public string Id { get; set; }
    }
}