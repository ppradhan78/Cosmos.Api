using Cosmos.NoSqlAPI.Data.SimpleModels;

namespace Cosmos.NoSqlAPI.Data.Core
{
    public interface IFeedProcessCosmosDBCore
    {
        Task<OrderSampleModel> AddRecord(OrderSampleModel order);
        Task<OrderSampleModel> UpdateRecord(string OrderId, string CustomerID, OrderSampleModel order);
        Task DeleteAsync(string OrderId, string CustomerID);
        Task<OrderSampleModel> GetByIdAsync(string OrderId, string CustomerID);
        Task<IEnumerable<OrderSampleModel>> GetAllAsync();
    }
}
