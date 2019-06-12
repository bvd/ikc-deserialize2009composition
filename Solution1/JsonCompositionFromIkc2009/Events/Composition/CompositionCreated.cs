namespace JsonCompositionFromIkc2009.Events.Composition
{
    public class CompositionCreated : IComposition
    {
        public CompositionCreated()
        {
            this.Type = this.GetType().AssemblyQualifiedName;
        }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Id { get; set; }
        public int? Time { get; set; }
        public int User { get; set; }
        public string UserName { get; set; }
        public string Conf { get; set; }
        public string Scroll { get; set; }
        public string Environment { get; set; }
    }
}