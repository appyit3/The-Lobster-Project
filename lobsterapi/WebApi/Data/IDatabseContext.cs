using Lobster.API.Entities;
using MongoDB.Driver;

namespace Lobster.API.Data
{
    public interface IDatabaseContext
    {
        IMongoCollection<User> Users { get; }
    }
}
