using System;
using System.Collections;
using System.Collections.Generic;

namespace Domain.Containers
{
    public interface IStorage
    {
        int Id { get; set; }
        string Name { get; set; }
        int Capacity { get; set; }
        IEnumerable<ITrackedItem> Items { get; set; }
        IEnumerable<Type> AcceptedItems { get; set; }
        IEnumerable<IStorage> SubStorages { get; set; }
    }
}