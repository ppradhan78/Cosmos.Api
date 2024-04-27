using Cosmos.NoSqlAPI.Data.BusinessObject;
using Cosmos.NoSqlAPI.Data.BusinessObjects;
using Cosmos.NoSqlAPI.Data.SimpleModels;
using Microsoft.Extensions.Configuration;

namespace Cosmos.NoSqlAPI.Data.Core
{
    public class FeedProcessCosmosDBCore : IFeedProcessCosmosDBCore
    {
        private readonly IFeedProcessCosmosDBBO _feedProcessCosmosDBBO;
        private readonly IConfigurationSettings _configuration;
        public FeedProcessCosmosDBCore(IConfigurationSettings configuration, IFeedProcessCosmosDBBO feedProcessCosmosDBBO)
        {
            _configuration = configuration;
            _feedProcessCosmosDBBO = feedProcessCosmosDBBO;
        }
       
        public Task<OrderSampleModel> AddRecord(OrderSampleModel order)
        {
           return _feedProcessCosmosDBBO.AddRecord(order);
        }

        public Task DeleteAsync(string OrderId,string CustomerID)
        {
            return _feedProcessCosmosDBBO.DeleteAsync(OrderId, CustomerID);

        }

        public Task<IEnumerable<OrderSampleModel>> GetAllAsync()
        {
            return _feedProcessCosmosDBBO.GetAllAsync();
        }

        public Task<OrderSampleModel> GetByIdAsync(string OrderId, string CustomerID)
        {
            return _feedProcessCosmosDBBO.GetByIdAsync(OrderId, CustomerID);
        }

        public Task<OrderSampleModel> UpdateRecord(string OrderId,string CustomerID, OrderSampleModel order)
        {
            return _feedProcessCosmosDBBO.UpdateRecord(OrderId,CustomerID, order);
        }
    }
}
