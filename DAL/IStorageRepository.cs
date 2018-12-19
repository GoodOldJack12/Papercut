using System.Collections;
using System.Collections.Generic;
using Domain.Containers;

namespace DAL
{
    public interface IStorageRepository
    {
        IStorage ReadStorage(int id);
        IEnumerable<IStorage> ReadAllStorage();

        IStorage CreateStorage(IStorage storage);
        IStorage UpdateStorage(IStorage storage);

        IStorage DeleteStorage(int id);

    }
}