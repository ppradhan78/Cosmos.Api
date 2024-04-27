using MongoDB.Driver;
namespace Cosmos.MongoDbAPI.Data.BusinessObjects.Base
{
    public interface IDatabaseContext
    {
        IMongoCollection<T> GetCollection<T>(string name);
    }
}
