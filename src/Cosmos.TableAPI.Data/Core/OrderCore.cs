using Cosmos.TableAPI.Data.BusinessObject;
using Cosmos.TableAPI.Data.BusinessObjects;
using Cosmos.TableAPI.Data.SimpleModels;

namespace Cosmos.TableAPI.Data.Core
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

        public Task<int> AddRecord(OrderDetailsSampleModel order)
        {
           return _orderBo.AddRecord(order);
        }

        public IEnumerable<OrderDetailsSampleModel> GetAll()
        {
            return _orderBo.GetAll();
        }

        public Task<OrderDetailsSampleModel> GetById(string RowKey, string partitionKey)
        {
            return _orderBo.GetById(RowKey, partitionKey);
        }

        public Task DeleteAsync(string RowKey, string partitionKey)
        {
            return _orderBo.DeleteAsync(RowKey, partitionKey);
        }

        public Task<int> UpdateRecord( OrderDetailsSampleModel order, string RowKey, string partitionKey)
        {
            return _orderBo.UpdateRecord(order, RowKey, partitionKey);
        }
    }
}
