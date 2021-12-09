using Lobster.API.Data;
using Lobster.API.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lobster.API.Repositories
{
    public class DatabaseRepository : IDatabaseRepository
    {
        private readonly IDatabaseContext _context;

        public DatabaseRepository(IDatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _context
                            .Users
                            .Find(u => true)
                            .ToListAsync();
        }

        public async Task<User> GetUser(int Id)
        {
            return await _context
                           .Users
                           .Find(p => p.Id == Id)
                           .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<User>> GetUserByName(string name)
        {
            FilterDefinition<User> filter = Builders<User>.Filter.ElemMatch(p => p.Username, name);

            return await _context
                            .Users
                            .Find(filter)
                            .ToListAsync();
        }

        public async Task CreateUser(User User)
        {
            await _context.Users.InsertOneAsync(User);
        }

        public async Task<bool> UpdateUser(User User)
        {
            var updateResult = await _context
                                        .Users
                                        .ReplaceOneAsync(filter: g => g.Id == User.Id, replacement: User);

            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> DeleteUser(int Id)
        {
            FilterDefinition<User> filter = Builders<User>.Filter.Eq(p => p.Id, Id);

            DeleteResult deleteResult = await _context
                                                .Users
                                                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }
    }
}
