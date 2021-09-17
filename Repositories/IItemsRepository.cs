using System;
using System.Collections.Generic;
using Catalog.Entities;

namespace Catalog.Repositories
{

    public interface IItemsRepository
    {
        Item GetItemById(Guid id);
        Item GetItemByName(String name);
        IEnumerable<Item> GetItems();
        void CreateItem(Item item);
        void UpdateItemById(Item item);
        void UpdateItemByName(Item item);
        void DeleteItemById(Guid id);
        void DeleteItemByName(String name);
    }
}