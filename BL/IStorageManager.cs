using System.Collections;
using System.Collections.Generic;
using Domain;
using Domain.Containers;

namespace BL
{
    public interface IStorageManager
    {
        IStorage GetStorage(int id);
        IStorage GetStorage(string name);
        IStorage AddStorage(IStorage storage);

        IStorage UpdateStorage(IStorage storage);
        IStorage RemoveStorage(int id);

        IEnumerable<IStorage> GetAllStorage();

    }
}