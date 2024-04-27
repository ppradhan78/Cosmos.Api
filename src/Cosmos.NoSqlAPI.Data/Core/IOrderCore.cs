using Cosmos.NoSqlAPI.Data.SimpleModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmos.NoSqlAPI.Data.Core
{
    public interface IOrderCore
    {
        Task<OrderDetailsSampleModel> AddRecord(OrderDetailsSampleModel order);
        Task<OrderDetailsSampleModel> UpdateRecord(string OrderId,string partitionKey, OrderDetailsSampleModel order);
        Task DeleteAsync(string OrderId, string partitionKey);
        Task<OrderDetailsSampleModel> GetByIdAsync(string OrderId, string partitionKey);
        Task<IEnumerable<OrderDetailsSampleModel>> GetAllAsync();
    }
}
