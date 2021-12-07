using System.Collections.Generic;
using System.Threading.Tasks;
using Lobsterapi.Entities;

namespace Lobsterapi.Helpers
{
    public interface IDatabaseRepository
    {
        // api/[GET]
        IEnumerable<User> GetAllUsers();
    }
}