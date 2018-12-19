using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Containers
{
    public class Bookshelf : IStorage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Book> Books { get; set; }
        
    }
}