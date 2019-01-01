using Domain;

namespace BL
{
    public interface ITrackedItemManager
    {
        ITrackedItem GetItem(int id);
        ITrackedItem UpdateItem(ITrackedItem item);
        ITrackedItem RemoveItem(ITrackedItem item);
        ITrackedItem AddItem(ITrackedItem item);
    }
}