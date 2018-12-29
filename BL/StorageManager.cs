using System;
using System.Linq;
using System.Xml;
using DAL;
using Domain;
using Domain.Containers;
using Domain.Extensions;

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

        public IStorage UpdateStorage(IStorage storage)
        {
            return repo.UpdateStorage(storage);
        }

        public IStorage RemoveStorage(int id)
        {
            return repo.DeleteStorage(id);
        }

        public IStorage AddItem(ITrackedItem item)
        {
            foreach (var storage in repo.ReadAllStorage())
            {
                if (storage.AcceptsItem(item))
                {
                    return AddItem(item, storage);
                }
            }

            return null;
        }

        public IStorage AddItem(ITrackedItem item, int storageID)
        {
            IStorage storage = GetStorage(storageID).GetStorageFor(item);
            return AddItem(item, storage);
        }

        public IStorage AddItem(ITrackedItem item, IStorage storage)
        {
            if (!storage.AcceptsItem(item))
            {
                return null;
            }
            storage?.Items.Add(item);
            return storage;
        }

        public ITrackedItem GetItem(int itemId)
        {
            IStorage storage = repo.ReadAllStorage().First(stor => stor.ContainsItem(itemId));
            return storage.GetItem(itemId);
        }
    }
}