using Catalog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Repositories
{
    public class InMemItemsRepository : IItemsRepository
    {
        private readonly List<Item> _items = new()
        {
            new Item { Id = Guid.NewGuid(), Name = "Health Potion", Price = 9, CreatedDate = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "Mana Potion", Price = 12, CreatedDate = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "Iron Sword", Price = 25, CreatedDate = DateTimeOffset.UtcNow },
        };

        public async Task<IEnumerable<Item>> GetItems()
        {
            return await Task.FromResult(_items);
        }

        public async Task<Item> GetItem(Guid id)
        {
            var item = _items.SingleOrDefault(item => item.Id == id);
            return await Task.FromResult(item);
        }

        public async Task CreateItem(Item item)
        {
            _items.Add(item);
            await Task.CompletedTask;
        }

        public async Task UpdateItem(Item item)
        {
            var index = _items.FindIndex(existingItem => existingItem.Id == item.Id);
            _items[index] = item;
            await Task.CompletedTask;
        }

        public async Task DeleteItem(Guid Id)
        {
            var index = _items.FindIndex(existingItem => existingItem.Id == Id);
            _items.RemoveAt(index);
            await Task.CompletedTask;
        }
    }
}
