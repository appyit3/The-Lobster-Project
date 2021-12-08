using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Linq;
using Lobsterapi.Entities;

namespace Lobsterapi.Data
{
    public class DatabaseRepository : IDatabaseRepository
    {
        private readonly IDatabaseContext _context;
        public DatabaseRepository(IDatabaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _context.Users.Find(u => true).ToListAsync();
        }
    }
}