using System;
using System.Collections.Generic;
using Domain;
using Domain.Containers;

namespace DAL
{
    public class RepoInMemory : IStorageRepository, ITrackedItemRepository
    {
        private List<IStorage> _storages;
        private List<ITrackedItem> _items;
        private static RepoInMemory me;
        private RepoInMemory()
        {
            _storages = new List<IStorage>();
            _items = new List<ITrackedItem>();
        }

        public static RepoInMemory Get()
        {
            return me ?? (me = new RepoInMemory()) ;
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

        public ITrackedItem ReadItem(int id)
        {
            return _items.Find(item => item.Id == id);
        }

        public ITrackedItem UpdateItem(ITrackedItem item)
        {
            //its in memory lol
            return item;
        }

        public ITrackedItem DeleteItem(ITrackedItem item)
        {
            _items.Remove(item);
            return item;
        }

        public ITrackedItem CreateItem(ITrackedItem item)
        {
            _items.Add(item);
            return item;
        }
    }
}