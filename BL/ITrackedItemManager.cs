using Domain;

namespace BL
{
    public interface ITrackedItemManager
    {
        ITrackedItem GetItem(int id);
        ITrackedItem UpdateItem(ITrackedItem item);
        ITrackedItem DeleteItem(ITrackedItem item);
        ITrackedItem AddItem(ITrackedItem item);
    }
}