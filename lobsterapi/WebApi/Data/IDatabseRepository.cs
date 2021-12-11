using Lobster.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lobster.API.Repositories
{
    public interface IDatabaseRepository
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(int Id);
        Task<IEnumerable<User>> GetUserByName(string name);
        Task<IEnumerable<User>> GetUser(string name, string password);

        Task<IEnumerable<TreeNode>> GetNodes(int StoryId);
    }
}
