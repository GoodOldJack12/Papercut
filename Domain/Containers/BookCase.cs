using System;
using System.Collections.Generic;

namespace Domain.Containers
{
    public class BookCase : IStorage
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Capacity
        {
            get
            {
                int capacity = 0;
                foreach (var shelf in SubStorages)
                {
                    capacity += shelf.Capacity;
                }

                return capacity;
            }
            set => throw new NotImplementedException();
        }

        public IEnumerable<ITrackedItem> Items
        {
            get
            {
                List<ITrackedItem> trackedItems = new List<ITrackedItem>();
                foreach (var shelve in SubStorages)
                {
                    trackedItems.AddRange(shelve.Items);
                }

                return trackedItems;
            }
            set => throw new NotImplementedException();
        }

        public IEnumerable<Type> AcceptedItems { get; set; } = new[] {typeof(Book)};
        public IEnumerable<IStorage> SubStorages { get; set; }
    }
}