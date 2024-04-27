using Cosmos.NoSqlAPI.Data.BusinessObject;
using Cosmos.NoSqlAPI.Data.SimpleModels;
using Microsoft.Azure.Cosmos;

namespace Cosmos.NoSqlAPI.Data.BusinessObjects
{
    public class FeedProcessCosmosDBBO : IFeedProcessCosmosDBBO
    {
        private readonly IConfigurationSettings _configuration;
        private readonly  string CosmosDbContainerName = "Order";
        public FeedProcessCosmosDBBO(IConfigurationSettings configuration)
        {
            _configuration = configuration;
        }

        public async Task<OrderSampleModel> AddRecord(OrderSampleModel order)
        {
            try
            {
                var collection = CosmosContainerClient();
                var response = await collection.CreateItemAsync<OrderSampleModel>(order, new Microsoft.Azure.Cosmos.PartitionKey(order.Customer.CustomerID));
                return response.Resource;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task DeleteAsync(string OrderId, string CustomerID)
        {
            var collection= CosmosContainerClient();
            await collection.DeleteItemAsync<OrderSampleModel>(OrderId, new Microsoft.Azure.Cosmos.PartitionKey(CustomerID));
        }

        public async Task<IEnumerable<OrderSampleModel>> GetAllAsync()
        {
            var _container = CosmosContainerClient();
            var query = _container.GetItemQueryIterator<OrderSampleModel>(new QueryDefinition("SELECT * FROM c"));
            var results = new List<OrderSampleModel>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response.ToList());
            }
            return results;
        }

        public async Task<OrderSampleModel> GetByIdAsync(string OrderId, string CustomerID)
        {
            var _container = CosmosContainerClient();
            ItemResponse<OrderSampleModel> response = await _container.ReadItemAsync<OrderSampleModel>(OrderId, new Microsoft.Azure.Cosmos.PartitionKey(CustomerID));
            return response.Resource;
        }

        public async Task<OrderSampleModel> UpdateRecord(string OrderId, string CustomerID, OrderSampleModel order)
        {
            var client = CosmosContainerClient();
            OrderSampleModel orderdetails = await client.ReadItemAsync<OrderSampleModel>(OrderId, new Microsoft.Azure.Cosmos.PartitionKey(CustomerID));
            orderdetails.ShipCity = order.ShipCity;
            orderdetails. ShipVia = order.ShipVia;
            orderdetails.ShipRegion = order.ShipRegion;
            orderdetails.ShipName = order.ShipName;
            orderdetails.CustomerID = order.Customer.CustomerID;
            var response = await client.UpsertItemAsync<OrderSampleModel>(order);
            return response.Resource;
        }
        private Container CosmosContainerClient()
        {
            CosmosClient cosmosDbClient = new CosmosClient(_configuration.CosmosDBAccountUri, _configuration.CosmosDBAccountPrimaryKey);
            var database = cosmosDbClient.GetDatabase(_configuration.CosmosDbName);
            var _container = database.GetContainer(CosmosDbContainerName);
            return _container;
        }
    }
}
