using System;
using System.Collections.Generic;
using System.Linq;
using Domain;
using Domain.Containers;
using Domain.Extensions;

namespace BL
{
    public class GlobalManager
    {
        private ITrackedItemManager _itemManager;
        private IStorageManager _storageManager;

        public GlobalManager()
        {
           //TODO initialize managers    
        }

        public List<ITrackedItem> GetItemsInStorage(int storageId)
        {
            return _storageManager.GetStorage(storageId).Items;
        }

        public IStorage AddItem(ITrackedItem item, int storageId)
        {
            
            if (GetLocationOf(item) != null)
            {
                return GetLocationOf(item);
            }
            if (_storageManager.GetStorage(storageId) == null)
            {
                return null;
            }

            var targetstorage = _storageManager.GetStorage(storageId).GetStorageFor(item);
            if (targetstorage != null)
            {
                targetstorage.Items.Add(item);
                item.StorageID = targetstorage.Id;
            }

            return targetstorage;
        }

        public ITrackedItem RemoveItem(ITrackedItem item)
        {
            var existingItem = _itemManager.GetItem(item.Id);
            if (existingItem == null)
            {
                return null;
            }

            GetLocationOf(item)?.Items.Remove(item);
            item.StorageID = null;
            _itemManager.DeleteItem(item);
            return item;
        }

        public IStorage GetLocationOf(ITrackedItem item)
        {
            IStorage found = null;
            var storageId = item.StorageID;
            if (storageId == null)
            {
                found = _storageManager.GetAllStorage().First(stor => stor.Items.Contains(item));
                var possibleSubStorage = found.SubStorages.First(stor => stor.Items.Contains(item));
                found = possibleSubStorage ?? found;
                item.StorageID = found.Id;
                Console.WriteLine($"The item {item.Name} with ID {item.Id} didn't have the storageID set, its been set to {found.Id}");
                return found;
            }

            found = _storageManager.GetStorage((int) storageId);
            return found.ContainsItem(item.Id) ? found : null;


        }
    }
}