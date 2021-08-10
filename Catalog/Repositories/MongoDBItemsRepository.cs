using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Catalog.Repositories
{
    public class MongoDBItemsRepository : IItemsRepository
    {
        private const string databaseName = "Catalog";
        private const string collectionName = "item";
        private readonly IMongoCollection<Item> itemsCollection;
        public readonly FilterDefinitionBuilder<Item> filterBuilder = Builders<Item>.Filter;
        public MongoDBItemsRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            itemsCollection = database.GetCollection<Item>(collectionName);
        }
        public async Task<Item> GetItem(Guid id)
        {
            var filter = filterBuilder.Eq(item => item.Id,id);
            return await itemsCollection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Item>> GetItems()
        {
            return await itemsCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task CreateItem(Item item)
        {
            await itemsCollection.InsertOneAsync(item);
        }

        public async Task UpdateItem(Item item)
        {
            var filter = filterBuilder.Eq(existingItem => existingItem.Id,item.Id);
            await itemsCollection.ReplaceOneAsync(filter, item);
        }

        public async Task DeleteItem(Guid Id)
        {
            var filter = filterBuilder.Eq(item => item.Id,Id);
            await itemsCollection.DeleteOneAsync(filter);
        }
    }
}