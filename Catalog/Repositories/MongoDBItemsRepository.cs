using System;
using System.Collections.Generic;
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
        public Item GetItem(Guid id)
        {
            var filter = filterBuilder.Eq(item => item.Id,id);
            return itemsCollection.Find(filter).SingleOrDefault();
        }

        public IEnumerable<Item> GetItems()
        {
            return itemsCollection.Find(new BsonDocument()).ToList();
        }

        public void CreateItem(Item item)
        {
            itemsCollection.InsertOne(item);
        }

        public void UpdateItem(Item item)
        {
            var filter = filterBuilder.Eq(existingItem => existingItem.Id,item.Id);
            itemsCollection.ReplaceOne(filter, item);
        }

        public void DeleteItem(Guid Id)
        {
            var filter = filterBuilder.Eq(item => item.Id,Id);
            itemsCollection.DeleteOne(filter);
        }
    }
}