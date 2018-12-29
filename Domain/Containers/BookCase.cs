using System;
using System.Collections.Generic;
using System.Linq;

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

        public List<ITrackedItem> Items
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
        public IStorage GetStorageFor(ITrackedItem item)
        {
            if (!AcceptedItems.Contains(item.GetType()))
            {
                return null;
            }
            foreach (var shelf in SubStorages)
            {
                if (shelf.Items.Count() < shelf.Capacity)
                {
                    return shelf;
                }
            }

            return null;
        }
    }
}