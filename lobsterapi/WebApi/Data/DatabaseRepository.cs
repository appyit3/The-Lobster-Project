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
            FilterDefinition<User> filter = Builders<User>.Filter.Where(p => p.Username == name);

            return await _context
                            .Users
                            .Find(filter)
                            .ToListAsync();
        }

        // public async Task<IEnumerable<User>> GetUser(string name, string password)
        // {
        //     FilterDefinition<User> filter = Builders<User>.Filter.Where(p => p.Username == name && p.Password == password);

        //     return await _context
        //                     .Users
        //                     .Find(filter)
        //                     .ToListAsync();
        // }

        public async Task<IEnumerable<TreeNode>> GetNodes(int StoryId)
        {
            return await _context
                           .TreeNodes
                           .Find(t => t.StoryId == StoryId)
                           .ToListAsync();
        }

        public async Task CreateHistory(UserHistory hist)
        {
            await _context.UserHistory.InsertOneAsync(hist);
        }

    }
}
