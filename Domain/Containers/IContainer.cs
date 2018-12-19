using System.Collections;
using System.Collections.Generic;

namespace Domain.Containers
{
    public interface IContainer
    {
        int Id { get; set; }
        string Name { get; set; }
    }
}