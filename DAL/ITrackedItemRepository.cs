using Domain;

namespace DAL
{
    public interface ITrackedItemRepository
    {
        ITrackedItem ReadItem(int id);
        ITrackedItem UpdateItem(ITrackedItem item);
        ITrackedItem DeleteItem(ITrackedItem item);

        ITrackedItem CreateItem(ITrackedItem item);
    }
}