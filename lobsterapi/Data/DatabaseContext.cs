using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using Lobsterapi.Entities;
using System.Collections;
using System.Collections.Generic;

namespace Lobsterapi.Data
{
    public interface IDatabaseContext
    {
        IMongoCollection<User> Users { get; }
    }

    public class DatabaseContext: IDatabaseContext
    {
        private readonly IMongoDatabase _db;

        public DatabaseContext(MongoDBConfig config)
        {
            var client = new MongoClient(config.ConnectionString);
            _db = client.GetDatabase(config.Database);  
            Users = _db.GetCollection<User>("users");
            SeedMongo.SeedUsers(Users);
        }

        public IMongoCollection<User> Users { get; }
    }
}