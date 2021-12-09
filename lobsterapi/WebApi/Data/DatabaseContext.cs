using Lobster.API.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Lobster.API.Data
{
    //For the entire database, I have only one context. You can have multiple contexts as per your domain.
    public class DatabaseContext : IDatabaseContext
    {
        public DatabaseContext(IConfiguration configuration)
        {            
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            Users = database.GetCollection<User>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
            DatabaseSeed.SeedData(Users);
        }

        public IMongoCollection<User> Users { get; }
    }
}
