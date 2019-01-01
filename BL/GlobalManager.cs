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
        public readonly ITrackedItemManager ItemManager;
        public readonly IStorageManager StorageManager;

        public GlobalManager()
        {
           ItemManager = new ItemManager();
           StorageManager = new StorageManager();
        }

        public List<ITrackedItem> GetItemsInStorage(int storageId)
        {
            return StorageManager.GetStorage(storageId).Items;
        }

        public IStorage AddItem(ITrackedItem item, int storageId)
        {
            
            if (GetLocationOf(item) != null)
            {
                return GetLocationOf(item);
            }
            if (StorageManager.GetStorage(storageId) == null)
            {
                return null;
            }

            var targetstorage = StorageManager.GetStorage(storageId).GetStorageFor(item);
            if (targetstorage != null)
            {
                targetstorage.Items.Add(item);
                item.StorageID = targetstorage.Id;
                ItemManager.AddItem(item);
            }

            return targetstorage;
        }

        public IStorage AddItem(ITrackedItem item)
        {
           var compatibleStorage = StorageManager.GetAllStorage().First(stor => stor.AcceptsItem(item));
           return AddItem(item, compatibleStorage.Id);
        }
        public ITrackedItem RemoveItem(ITrackedItem item)
        {
            var existingItem = ItemManager.GetItem(item.Id);
            if (existingItem == null)
            {
                return null;
            }

            GetLocationOf(item)?.Items.Remove(item);
            return ItemManager.RemoveItem(item);
        }

        public IStorage GetLocationOf(ITrackedItem item)
        {
            IStorage found = null;
            var storageId = item.StorageID;
            if (storageId == null)
            {
                found = StorageManager.GetAllStorage().FirstOrDefault(stor => stor.Items.Contains(item));
                if (found == null)
                {
                    return null;
                }
                var possibleSubStorage = found.SubStorages.First(stor => stor.Items.Contains(item));
                found = possibleSubStorage ?? found;
                item.StorageID = found.Id;
                Console.WriteLine($"The item {item.Name} with ID {item.Id} didn't have the storageID set, its been set to {found.Id}");
                return found;
            }

            found = StorageManager.GetStorage((int) storageId);
            return found.ContainsItem(item.Id) ? found : null;
        }

        public IStorage AddStorage(IStorage storage)
        {
            return StorageManager.AddStorage(storage);
        }
    }
}