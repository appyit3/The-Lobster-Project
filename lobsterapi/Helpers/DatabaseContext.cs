using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using Lobsterapi.Entities;
using System.Collections;
using System.Collections.Generic;

namespace Lobsterapi.Helpers
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
            var settings = MongoClientSettings.FromConnectionString(config.ConnectionString);
            settings.SslSettings = new SslSettings() { EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12 };
            var client = new MongoClient(settings);
            _db = client.GetDatabase(config.Database);   
        }
        public IMongoCollection<User> Users => _db.GetCollection<User>("Users");
    }
}