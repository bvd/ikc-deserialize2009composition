namespace JsonCompositionFromIkc2009.Events.Composition
{
    public class ClearCompositionEvent : IComposition
    {
        public ClearCompositionEvent()
        {
            this.Type = this.GetType().AssemblyQualifiedName;
        }

        public string Type { get; set; }
    }
}
