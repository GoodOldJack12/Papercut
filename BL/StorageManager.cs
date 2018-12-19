using System;
using System.Linq;
using System.Xml;
using DAL;
using Domain;
using Domain.Containers;

namespace BL
{
    public class StorageManager : IStorageManager
    {
        private IStorageRepository repo;

        public StorageManager()
        {
            repo = new StorageRepoInMemory();
        }

        public IStorage GetStorage(int id)
        {
            return repo.ReadStorage(id);
        }

        public IStorage GetStorage(string name)
        {
            return repo.ReadAllStorage().Single(stor => stor.Name.Equals(name));
        }

        public IStorage AddStorage(IStorage storage)
        {
            return repo.CreateStorage(storage);
        }

        public IStorage UpdateStorage(int id)
        {
            throw new NotImplementedException();
        }

        public IStorage RemoveStorage(int id)
        {
            throw new NotImplementedException();
        }

        public ITrackedItem AddItem(ITrackedItem item)
        {
            throw new NotImplementedException();
        }

        public ITrackedItem GetItem(int itemId)
        {
            throw new NotImplementedException();
        }
    }
}