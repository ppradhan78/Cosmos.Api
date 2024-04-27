using Cosmos.MongoDbAPI.Controllers.Base;
using Cosmos.MongoDbAPI.Data.Core;
using Cosmos.MongoDbAPI.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cosmos.MongoDbAPI.Controllers
{
    [ApiController]
    [Route("OrderDetailsAPI/v1/[controller]")]
    public class OrderDetailsController : BaseController<OrderDetails>
    {
        public OrderDetailsController(IOrderDetailsCore repository, ILogger<OrderDetails> logger) : base(repository, logger)
        {
        }
    }
}
