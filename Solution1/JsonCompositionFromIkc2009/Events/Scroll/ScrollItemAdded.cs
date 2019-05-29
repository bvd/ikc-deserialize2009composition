namespace JsonCompositionFromIkc2009.Events.Scroll
{
    public class ScrollItemAdded : IScroll
    {
        public ScrollItemAdded()
        {
            this.Type = this.GetType().AssemblyQualifiedName;
        }
        public string Type { get; set; }
        public string Name { get; set; }
        public int Index { get; set; }
        public string Id { get; set; }
    }
}