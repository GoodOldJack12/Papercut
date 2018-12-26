using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Containers
{
    public class Bookshelf : IStorage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public IEnumerable<ITrackedItem> Items { get; set; }
        public IEnumerable<Type> AcceptedItems { get; set; }= new[] {typeof(Book)};
        public IEnumerable<IStorage> SubStorages { get; set; }
        public List<Book> Books { get; set; }
        
    }
}