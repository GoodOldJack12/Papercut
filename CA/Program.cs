using System;
using System.Collections.Generic;
using System.Linq;
using BL;
using Domain;
using Domain.Containers;

namespace CA
{
    class Program
    {
        private static GlobalManager manager;
        static void Main(string[] args)
        {
            Console.WriteLine("Get ready to get cut..");
            manager = new GlobalManager();
            Seed();
            var containers = manager.StorageManager.GetAllStorage();
            foreach (var container in containers)
            {
                string acceptedTypes = "";
                container.AcceptedItems.ToList().ForEach(type => acceptedTypes += $" {type.Name}");
                Console.WriteLine($"Storage \"{container.Name}\" of type {container.GetType().Name} with {container.Capacity} capacity. Accepts {acceptedTypes.Substring(1)}");
                if (container.SubStorages.Any())
                {
                    Console.WriteLine($"Contains sub containers:");
                    foreach (var containerSubStorage in container.SubStorages)
                    {
                        Console.WriteLine($" Storage {containerSubStorage.Name} of type {containerSubStorage.GetType().Name} with {containerSubStorage.Capacity} capacity");

                    }
                }
            }
            
            var items = manager.StorageManager.GetStorage("BookCase A").Items;
            Console.WriteLine("Items in book case A:");
            items.ForEach(item => { Console.WriteLine($"Item of type {item.GetType().Name}\n Name: {item.Name}"); } );
        }

        private static void Seed()
        {
            for (char letter = 'A'; letter <= 'D'; letter++)
            {
                List<Bookshelf> bookshelves = new List<Bookshelf>();
                for (int i = 0; i < 5; i++)
                {
                    bookshelves.Add(new Bookshelf($"Shelf {i}",10));
                }
                BookCase somecase = new BookCase() {Name = $"BookCase {letter}",SubStorages = bookshelves};
                manager.AddStorage(somecase);
            }

            Book book = new Book{Name = "Hitchhikers guide to the galaxy", Author = "Douglas Adams", ISBN = "12345"};

            manager.AddItem(book);
        }
    }
}