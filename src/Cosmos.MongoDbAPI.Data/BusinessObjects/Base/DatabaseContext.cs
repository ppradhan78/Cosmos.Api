using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
namespace Cosmos.MongoDbAPI.Data.BusinessObjects.Base
{
    public class DatabaseContext : IDatabaseContext
    {
        private readonly IMongoDatabase _database;
        private readonly IMongoClient _client;
        public DatabaseContext(IConfiguration configuration)
        {
            _client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            _database = _client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));
        }
        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return _database.GetCollection<T>(name);
        }
    }
}
