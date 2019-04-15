using Microsoft.WindowsAzure.Storage.Table;

namespace JsonCompositionFromIkc2009.Events.Composition
{
    public class CompositionCreated : TableEntity, IComposition
    {
        public string Type
        {
            get
            {
                return this.GetType().AssemblyQualifiedName;
            }
        }
        public string Name { get; set; }
        public int Id { get; set; }
        public int? Time { get; set; }
        public int User { get; set; }
        public string UserName { get; set; }
        public string Conf { get; set; }
        public string Scroll { get; set; }
        public string Environment { get; set; }
    }
}