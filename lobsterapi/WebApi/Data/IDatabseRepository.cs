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

        Task CreateUser(User user);
        Task<bool> UpdateUser(User user);
        Task<bool> DeleteUser(int Id);
    }
}
