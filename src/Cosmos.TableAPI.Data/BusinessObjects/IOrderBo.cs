using Cosmos.TableAPI.Data.SimpleModels;

namespace Cosmos.TableAPI.Data.BusinessObjects
{
    public interface IOrderBo
    {
        Task<int> AddRecord(OrderDetailsSampleModel order);
        IEnumerable<OrderDetailsSampleModel> GetAll();
        Task<OrderDetailsSampleModel> GetById(string RowKey, string partitionKey);
        Task DeleteAsync(string RowKey, string partitionKey);
        Task<int> UpdateRecord(OrderDetailsSampleModel order, string RowKey, string partitionKey);
    }
}
