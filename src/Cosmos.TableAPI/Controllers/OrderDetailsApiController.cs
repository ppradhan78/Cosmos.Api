using Cosmos.TableAPI.Data.BusinessObject;
using Cosmos.TableAPI.Data.Core;
using Cosmos.TableAPI.Data.SimpleModels;
using Microsoft.AspNetCore.Mvc;

namespace Cosmos.TableAPI.Controllers
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

        //[HttpGet("{partitionKey}")]
        [HttpGet()]
        public IEnumerable<OrderDetailsSampleModel> Get()
        {
            return _orderCore.GetAll();
        }
            
        [HttpGet("{partitionKey}/{RowKey}")]
        public Task< OrderDetailsSampleModel> Get(string RowKey, string partitionKey)
        {
            return _orderCore.GetById(RowKey, partitionKey);
        }

        [HttpPost]
        public Task<int> Post([FromBody] OrderDetailsSampleModel value)
        {
            return _orderCore.AddRecord(value);
        }

        [HttpPut("{partitionKey}/{RowKey}")]
        public Task<int> Put([FromBody] OrderDetailsSampleModel value, string RowKey, string partitionKey)
        {
            return _orderCore.UpdateRecord(value,  RowKey,  partitionKey);
        }

        [HttpDelete("{partitionKey}/{RowKey}")]
        public async Task Delete(string RowKey, string partitionKey)
        {
            await _orderCore.DeleteAsync(RowKey, partitionKey);
        }
    }
}
