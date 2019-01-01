using System;
using System.Collections.Generic;
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

        public IEnumerable<IStorage> GetAllStorage()
        {
            return repo.ReadAllStorage().AsEnumerable();
        }
    }
}