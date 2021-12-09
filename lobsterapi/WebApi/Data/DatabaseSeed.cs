using Lobster.API.Entities;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace Lobster.API.Data
{
    public class DatabaseSeed
    {
        public static void SeedData(IMongoCollection<User> Users)
        {
            bool existUser = Users.Find(p => true).Any();
            if (!existUser)
            {
                Users.InsertManyAsync(GetPreconfiguredUsers());
            }
        }

        private static IEnumerable<User> GetPreconfiguredUsers()
        {
            return new List<User>()
            {
                new User()
                {
                    Id= 1,
                    Username= "test",
                    Password= "test"
                },
                new User()
                {
                    Id= 2,
                    Username= "Wolverine",
                    Password= "Wolverine"
                },
                new User()
                {
                    Id= 3,
                    Username= "Raven",
                    Password= "Raven"
                },
                new User()
                {
                    Id= 4,
                    Username= "Rogue",
                    Password= "Rogue"
                },
                new User()
                {
                    Id= 5,
                    Username= "Magneto",
                    Password= "Magneto"
                },
                new User()
                {
                    Id= 6,
                    Username= "Sabretooth",
                    Password= "Sabretooth"
                },
                new User()
                {
                    Id= 7,
                    Username= "Pyro",
                    Password= "Pyro"
                }
            };
        }
    }
}
