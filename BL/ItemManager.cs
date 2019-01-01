using DAL;
using Domain;

namespace BL
{
    public class ItemManager : ITrackedItemManager
    {
        private ITrackedItemRepository repo;
        public ITrackedItem GetItem(int id)
        {
            return repo.ReadItem(id);
        }

        public ITrackedItem UpdateItem(ITrackedItem item)
        {
            return repo.UpdateItem(item);
        }

        public ITrackedItem RemoveItem(ITrackedItem item)
        {
            item.StorageID = null;
            return repo.DeleteItem(item);
        }

        public ITrackedItem AddItem(ITrackedItem item)
        {
            return repo.CreateItem(item);
        }
    }
}