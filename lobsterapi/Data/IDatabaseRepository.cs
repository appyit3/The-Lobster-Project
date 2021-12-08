using System.Collections.Generic;
using System.Threading.Tasks;
using Lobsterapi.Entities;

namespace Lobsterapi.Data
{
    public interface IDatabaseRepository
    {
        // api/[GET]
        Task<IEnumerable<User>> GetAllUsers();
    }
}