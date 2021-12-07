using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Linq;
using Lobsterapi.Entities;

namespace Lobsterapi.Helpers
{
    public class DatabaseRepository : IDatabaseRepository
    {
        private readonly IDatabaseContext _context;
        public DatabaseRepository(IDatabaseContext context)
        {
            _context = context;
        }
        public IEnumerable<User> GetAllUsers()
        {
            return  _context.Users.Find(_ => true).ToList();
        }
    }
}