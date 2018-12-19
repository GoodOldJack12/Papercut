using System;
using System.Collections.Generic;
using Domain.Containers;

namespace DAL
{
    public class StorageRepoInMemory : IStorageRepository
    {
        private List<IStorage> _storages;
        public StorageRepoInMemory()
        {
            _storages = new List<IStorage>();
        }

        public IStorage ReadStorage(int id)
        {
            return _storages.Find(stor => stor.Id.Equals(id));
        }

        public IEnumerable<IStorage> ReadAllStorage()
        {
            return _storages;
        }

        public IStorage CreateStorage(IStorage storage)
        {
            if (ReadStorage(storage.Id) == null)
            {
                _storages.Add(storage);
            }

            return storage;
        }

        public IStorage UpdateStorage(IStorage storage)
        {
            //pointless
            return storage;
        }

        public IStorage DeleteStorage(int id)
        {
            IStorage toRemove = ReadStorage(id);
            if (toRemove != null)
            {
                _storages.Remove(toRemove);
            }

            return toRemove;
        }
    }
}