using Domain;
using Domain.Containers;

namespace BL
{
    public interface IStorageManager
    {
        IStorage GetStorage(int id);
        IStorage GetStorage(string name);
        IStorage AddStorage(IStorage storage);

        IStorage UpdateStorage(int id);
        IStorage RemoveStorage(int id);

        ITrackedItem AddItem(ITrackedItem item);
        ITrackedItem GetItem(int itemId);
        
    }
}