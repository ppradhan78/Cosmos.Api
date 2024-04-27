using Cosmos.NoSqlAPI.Data.BusinessObject;
using Cosmos.NoSqlAPI.Data.SimpleModels;
using Microsoft.Azure.Cosmos;

namespace Cosmos.NoSqlAPI.Data.BusinessObjects
{
    public class OrderBo: IOrderBo
    {
        private readonly IConfigurationSettings _configuration;
        private readonly string CosmosDbContainerName = "OrderDetails";
        public OrderBo(IConfigurationSettings configuration)
        {
            _configuration = configuration;
        }

        public async Task<OrderDetailsSampleModel> AddRecord(OrderDetailsSampleModel order)
        {
            try
            {
                //order.Id = Guid.NewGuid().ToString();
                var collection = CosmosContainerClient();
                var response = await collection.CreateItemAsync<OrderDetailsSampleModel>(order, new PartitionKey(order.productId));
                return response.Resource;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<OrderDetailsSampleModel> UpdateRecord(string OrderId,string partitionKey, OrderDetailsSampleModel order)
        {
            try
            {
                var client = CosmosContainerClient();
                OrderDetailsSampleModel orderdetails = await client.ReadItemAsync<OrderDetailsSampleModel>(OrderId, new PartitionKey(partitionKey));
                orderdetails.productId = order.productId;
                orderdetails.unitPrice = order.unitPrice;
                orderdetails.quantity = order.quantity;
                orderdetails.discount = order.discount;
                var response = await client.UpsertItemAsync<OrderDetailsSampleModel>(orderdetails);
                return response.Resource;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
      
        public async Task DeleteAsync(string OrderId, string partitionKey)
        {
            try
            {
                var collection = CosmosContainerClient();
                await collection.DeleteItemAsync<OrderDetailsSampleModel>(OrderId, new PartitionKey(partitionKey));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<OrderDetailsSampleModel>> GetAllAsync()
        {
            try
            {
                var _container = CosmosContainerClient();
                var query = _container.GetItemQueryIterator<OrderDetailsSampleModel>(new QueryDefinition("SELECT * FROM OrderDetails"));
                var results = new List<OrderDetailsSampleModel>();
                while (query.HasMoreResults)
                {
                    var response = await query.ReadNextAsync();
                    results.AddRange(response.ToList());
                }
                return results;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<OrderDetailsSampleModel> GetByIdAsync(string OrderId, string partitionKey)
        {
            try
            {
                var _container = CosmosContainerClient();
                ItemResponse<OrderDetailsSampleModel> response = await _container.ReadItemAsync<OrderDetailsSampleModel>(OrderId, new PartitionKey(partitionKey));
                return response.Resource;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
     
        //CosmosClient
        private Container CosmosContainerClient()
        {
            CosmosClient cosmosDbClient = new CosmosClient(_configuration.CosmosDBAccountUri, _configuration.CosmosDBAccountPrimaryKey);
            var database = cosmosDbClient.GetDatabase(_configuration.CosmosDbName);
            var _container = database.GetContainer(CosmosDbContainerName);
            return _container;
        }
    }
}
