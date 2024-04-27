using Cosmos.NoSqlAPI.Data.BusinessObject;
using Cosmos.NoSqlAPI.Data.BusinessObjects;
using Cosmos.NoSqlAPI.Data.Core;
using Cosmos.NoSqlAPI.Data.SimpleModels;
using Microsoft.AspNetCore.Mvc;

namespace Cosmos.NoSqlAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderApiController : ControllerBase
    {
        private readonly IFeedProcessCosmosDBCore _feedProcessCosmosDBCore;
        private readonly IConfigurationSettings _configuration;

        public OrderApiController(IConfigurationSettings configuration, IFeedProcessCosmosDBCore feedProcessCosmosDBCore)
        {
            _configuration = configuration;
            _feedProcessCosmosDBCore = feedProcessCosmosDBCore;
        }

        [HttpGet]
        public IEnumerable<OrderSampleModel> Get()
        {
            return _feedProcessCosmosDBCore.GetAllAsync().Result;
        }

        [HttpGet("{CustomerID}/{OrderId}")]
        public OrderSampleModel Get(string CustomerID,string OrderId)
        {
            return _feedProcessCosmosDBCore.GetByIdAsync(OrderId, CustomerID).Result;
            //if (output!=null)
            //{
            //    return output.Result;
            //}
        }

        [HttpPost]
        public OrderSampleModel Post([FromBody] OrderSampleModel value)
        {
            try
            {
                return _feedProcessCosmosDBCore.AddRecord(value).Result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPut("{CustomerID}/{OrderId}")]
        public OrderSampleModel Put(string CustomerID,string OrderId,[FromBody] OrderSampleModel value)
        {
            return _feedProcessCosmosDBCore.UpdateRecord(OrderId, CustomerID, value).Result;
        }

        [HttpDelete("{CustomerID}/{OrderId}")]
        public void Delete(string CustomerID,string OrderId)
        {
            _feedProcessCosmosDBCore.DeleteAsync(OrderId, CustomerID);
        }
    }
}
