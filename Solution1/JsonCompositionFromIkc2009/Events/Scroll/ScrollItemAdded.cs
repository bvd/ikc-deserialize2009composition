using Microsoft.WindowsAzure.Storage.Table;

namespace JsonCompositionFromIkc2009.Events.Scroll
{
    internal class ScrollItemAdded : TableEntity, IScroll
    {
        public string Name { get; set; }
        public int Index { get; set; }
        public int Id { get; set; }
    }
}