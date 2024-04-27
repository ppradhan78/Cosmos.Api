using Cosmos.MongoDbAPI.Data.BusinessObjects.Base;
using Cosmos.MongoDbAPI.Data.Entities;

namespace Cosmos.MongoDbAPI.Data.BusinessObjects
{
    public class OrderDetailsRepository : BaseRepository<OrderDetails>, IOrderDetailsRepository
    {
        public OrderDetailsRepository(IDatabaseContext context) : base(context)
        {
        }
    }
}
