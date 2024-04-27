using Cosmos.MongoDbAPI.Data.BusinessObjects.Base;
using Cosmos.MongoDbAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmos.MongoDbAPI.Data.BusinessObjects
{
    public interface IOrderDetailsRepository : IBaseRepository<OrderDetails>
    {
    }
}
