using System.Collections;
using System.Collections.Generic;

namespace Domain.Containers
{
    public interface IStorage
    {
        int Id { get; set; }
        string Name { get; set; }
    }
}