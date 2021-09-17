using System;
using System.Collections.Generic;
using System.Linq;
using Catalog.Entities;

namespace Catalog.Repositories
{
    public class InMemItemsRepository : IItemsRepository
    {
        private readonly List<Item> items = new()
        {
            new Item { Id = Guid.NewGuid(), Name = "Potion", Price = 9, CreatedDate = System.DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "Iron Sword", Price = 20, CreatedDate = System.DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "Bronze Shield", Price = 18, CreatedDate = System.DateTimeOffset.UtcNow }
        };

        public IEnumerable<Item> GetItems()
        {
            return items;
        }

        public Item GetItemById(Guid id)
        {
            return items.Where(item => item.Id == id).SingleOrDefault();
        }

        public Item GetItemByName(String name)
        {
            return items.Where(item => item.Name == name).SingleOrDefault();
        }

        public void CreateItem(Item item)
        {
            items.Add(item);
        }

        public void UpdateItemById(Item item)
        {
            var index = items.FindIndex(existingItem => existingItem.Id == item.Id);
            items[index] = item;
        }
        public void UpdateItemByName(Item item)
        {
            var index = items.FindIndex(existingItem => existingItem.Name == item.Name);
            items[index] = item;
        }

        public void DeleteItemById(Guid id)
        {
            var index = items.FindIndex(existingItem => existingItem.Id == id);
            items.RemoveAt(index);
        }
        public void DeleteItemByName(String name)
        {
            var index = items.FindIndex(existingItem => existingItem.Name == name);
            items.RemoveAt(index);
        }
    }
}