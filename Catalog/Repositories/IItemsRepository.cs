using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.Entities;

namespace Catalog.Repositories
{
    public interface IItemsRepository
    {
        Task<Item> GetItem(Guid id);
        Task<IEnumerable<Item>> GetItems();
        Task CreateItem(Item item);
        Task UpdateItem(Item item);
        Task DeleteItem(Guid Id);
    }
}