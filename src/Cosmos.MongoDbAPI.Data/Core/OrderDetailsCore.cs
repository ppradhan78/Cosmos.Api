using Cosmos.MongoDbAPI.Data.BusinessObjects;
using Cosmos.MongoDbAPI.Data.BusinessObjects.Base;
using Cosmos.MongoDbAPI.Data.Entities;

namespace Cosmos.MongoDbAPI.Data.Core
{

    public class OrderDetailsCore : BaseCore<OrderDetails>,IOrderDetailsCore
    {
        public OrderDetailsCore(IOrderDetailsRepository repository) : base(repository)
        {
        }
    }
}
