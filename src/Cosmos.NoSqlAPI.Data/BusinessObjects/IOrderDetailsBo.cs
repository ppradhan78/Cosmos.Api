using Cosmos.NoSqlAPI.Data.SimpleModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmos.NoSqlAPI.Data.BusinessObjects
{
    public  interface IOrderDetailsBo
    {
        Task<IEnumerable<OrderSampleModel>> GetItemsAsync(string query);

        Task<OrderSampleModel> GetItemAsync(string id);

        Task AddItemAsync(OrderSampleModel item);

        Task UpdateItemAsync(string id, OrderSampleModel item);

        Task DeleteItemAsync(string id);
    }
}
