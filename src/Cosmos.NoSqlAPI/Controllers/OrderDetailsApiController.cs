using Cosmos.NoSqlAPI.Data.BusinessObject;
using Cosmos.NoSqlAPI.Data.Core;
using Cosmos.NoSqlAPI.Data.SimpleModels;
using Microsoft.AspNetCore.Mvc;

namespace Cosmos.NoSqlAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsApiController : ControllerBase
    {
        private readonly IOrderCore _orderCore;
        private readonly IConfigurationSettings _configuration;

        public OrderDetailsApiController(IConfigurationSettings configuration, IOrderCore orderCore)
        {
            _configuration = configuration;
            _orderCore = orderCore;
        }

        [HttpGet]
        public  Task<IEnumerable<OrderDetailsSampleModel>> Get()
        {
            return  _orderCore.GetAllAsync();
        }

        [HttpGet("{partitionKey}/{OrderId}")]
        public async Task<OrderDetailsSampleModel> Get(string OrderId,string partitionKey)
        {
            return await _orderCore.GetByIdAsync(OrderId, partitionKey);
        }

        [HttpPost]
        public async Task Post([FromBody] OrderDetailsSampleModel value)
        {
            await _orderCore.AddRecord(value);
        }

        [HttpPut("{partitionKey}/{OrderId}")]
        public async Task Put(string OrderId, string partitionKey, [FromBody] OrderDetailsSampleModel value)
        {
            await _orderCore.UpdateRecord(OrderId, partitionKey, value);
        }

        [HttpDelete("{partitionKey}/{OrderId}")]
        public async Task Delete(string OrderId, string partitionKey)
        {
            await _orderCore.DeleteAsync(OrderId, partitionKey);
        }
    }
}
