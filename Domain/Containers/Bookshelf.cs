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
        public List<ITrackedItem> Items { get; set; }
        public IEnumerable<Type> AcceptedItems { get; set; }= new[] {typeof(Book)};
        public IEnumerable<IStorage> SubStorages { get; set; }
        public IStorage GetStorageFor(ITrackedItem item)
        {
            if (AcceptedItems.Contains(item.GetType())&& Items.Count() < Capacity)
            {
                return this;
            }
            return null;
        }        
    }
}