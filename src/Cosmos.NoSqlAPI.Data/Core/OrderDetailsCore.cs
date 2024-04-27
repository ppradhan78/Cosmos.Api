using Cosmos.NoSqlAPI.Data.BusinessObject;
using Cosmos.NoSqlAPI.Data.BusinessObjects;
using Cosmos.NoSqlAPI.Data.SimpleModels;
using Microsoft.Azure.Cosmos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmos.NoSqlAPI.Data.Core
{
    public class OrderDetailsCore : IOrderDetailsCore
    {
        private readonly IConfigurationSettings _configuration;
        private readonly IOrderDetailsBo _orderDetailsBo;
        public OrderDetailsCore(IOrderDetailsBo orderDetailsBo, IConfigurationSettings configuration)
        {
            _configuration = configuration;
            _orderDetailsBo = orderDetailsBo;
        }

        public async Task AddItemAsync(OrderSampleModel item)
        {
           await _orderDetailsBo.AddItemAsync(item);
        }

        public async Task DeleteItemAsync(string id)
        {
            await _orderDetailsBo.DeleteItemAsync(id);
        }

        public async Task<OrderSampleModel> GetItemAsync(string id)
        {
           return await _orderDetailsBo.GetItemAsync(id);
        }

        public async Task<IEnumerable<OrderSampleModel>> GetItemsAsync(string query)
        {
            return await _orderDetailsBo.GetItemsAsync(query);
        }

        public async Task UpdateItemAsync(string id, OrderSampleModel item)
        {
             await _orderDetailsBo.UpdateItemAsync(id, item);
        }
    }
}
