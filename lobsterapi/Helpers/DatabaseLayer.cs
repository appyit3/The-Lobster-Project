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
        List<User> Users { get; }
    }

    public class DatabaseContext: IDatabaseContext
    {
        private readonly IMongoDatabase _db;
        private readonly AppSettings _appSettings;

        public DatabaseContext(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
            var settings = MongoClientSettings.FromConnectionString(_appSettings.ConnectionString);
            settings.SslSettings = new SslSettings() { EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12 };
            // settings.Server = new MongoServerAddress(_appSettings.ConnectionString);
            var client = new MongoClient(settings);
            _db = client.GetDatabase(_appSettings.Database);   
        }
        public List<User> Users => _db.GetCollection<User>("Users").AsQueryable<User>().ToList();
    }
}