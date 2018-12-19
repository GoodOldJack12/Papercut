using System.Collections.Generic;

namespace Domain.Containers
{
    public class BookCase : IContainer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Bookshelf> Shelves { get; set; }
        
    }
}