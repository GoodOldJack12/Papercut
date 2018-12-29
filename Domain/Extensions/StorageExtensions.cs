using System.ComponentModel;
using System.Linq;
using Domain.Containers;

namespace Domain.Extensions
{
    public static class ContainerExtensions
    {
        public static bool AcceptsItem(this IStorage storage,ITrackedItem item)
        {
            return storage.AcceptedItems.Contains(item.GetType()) && storage.IsFull();
        }

        public static bool IsFull(this IStorage storage)
        {
            return storage.Capacity >= storage.Items.Count();
        }

        public static bool ContainsItem(this IStorage storage, int itemId)
        {
            return storage.Items.Exists(item => item.Id.Equals(itemId));
        }

        public static ITrackedItem GetItem(this IStorage storage, int itemId)
        {
            return storage.Items.First(item => item.Id.Equals(itemId));
        }
    }
}