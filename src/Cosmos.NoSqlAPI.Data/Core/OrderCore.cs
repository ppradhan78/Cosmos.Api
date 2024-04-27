using Cosmos.NoSqlAPI.Data.BusinessObject;
using Cosmos.NoSqlAPI.Data.BusinessObjects;
using Cosmos.NoSqlAPI.Data.SimpleModels;

namespace Cosmos.NoSqlAPI.Data.Core
{
    public class OrderCore : IOrderCore
    {
        private readonly IOrderBo _orderBo;
        private readonly IConfigurationSettings _configuration;
        public OrderCore(IConfigurationSettings configuration, IOrderBo orderBo)
        {
            _configuration = configuration;
            _orderBo = orderBo;
        }

        public Task<OrderDetailsSampleModel> AddRecord(OrderDetailsSampleModel order)
        {
           return _orderBo.AddRecord(order);
        }

        public Task DeleteAsync(string OrderId, string partitionKey)
        {
            return _orderBo.DeleteAsync(OrderId,partitionKey);
        }

        public Task<IEnumerable<OrderDetailsSampleModel>> GetAllAsync()
        {
            return _orderBo.GetAllAsync();
        }

        public Task<OrderDetailsSampleModel> GetByIdAsync(string OrderId, string partitionKey)
        {
            return _orderBo.GetByIdAsync(OrderId, partitionKey);

        }

        public Task<OrderDetailsSampleModel> UpdateRecord(string OrderId, string partitionKey, OrderDetailsSampleModel order)
        {
            return _orderBo.UpdateRecord(OrderId, partitionKey, order);
        }
    }
}
