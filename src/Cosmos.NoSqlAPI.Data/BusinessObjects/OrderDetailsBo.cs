using Cosmos.NoSqlAPI.Data.BusinessObject;
using Cosmos.NoSqlAPI.Data.SimpleModels;
using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmos.NoSqlAPI.Data.BusinessObjects
{
    public class OrderDetailsBo : IOrderDetailsBo
    {
        private Container _container;
        private readonly IConfigurationSettings _configuration;

        public OrderDetailsBo(CosmosClient dbClient, IConfigurationSettings configuration)
        {
            _configuration = configuration;
            this._container = dbClient.GetContainer(_configuration.CosmosDbName, "OrderDetails");
        }

        public async Task AddItemAsync(OrderSampleModel item)
        {
            await this._container.CreateItemAsync<OrderSampleModel>(item, new PartitionKey(item.Customer.CustomerID));
        }

        public async Task DeleteItemAsync(string id)
        {
            await this._container.DeleteItemAsync<OrderSampleModel>(id, new PartitionKey(id));
        }

        public async Task<OrderSampleModel> GetItemAsync(string id)
        {
            try
            {
                ItemResponse<OrderSampleModel> response = await this._container.ReadItemAsync<OrderSampleModel>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task<IEnumerable<OrderSampleModel>> GetItemsAsync(string queryString)
        {
            var query = this._container.GetItemQueryIterator<OrderSampleModel>(new QueryDefinition(queryString));
            List<OrderSampleModel> results = new List<OrderSampleModel>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response.ToList());
            }
            return results;
        }

        public async Task UpdateItemAsync(string id, OrderSampleModel item)
        {
            await this._container.UpsertItemAsync<OrderSampleModel>(item, new PartitionKey(id));
        }
    }
}
