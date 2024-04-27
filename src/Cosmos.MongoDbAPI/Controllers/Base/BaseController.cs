using Cosmos.MongoDbAPI.Data.BusinessObjects.Base;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Net;

namespace Cosmos.MongoDbAPI.Controllers.Base
{
    public abstract class BaseController<T> : Controller where T : class
    {
        private readonly IBaseCore<T> _core;
        private readonly ILogger<T> _logger;

        public BaseController(IBaseCore<T> core, ILogger<T> logger)
        {
            _core = core;
            _logger = logger;
        }

        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<T>>> Get()
        {
            var result = await _core.GetAll();
            return Ok(result);
        }

        [HttpGet("{Id:length(24)}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public virtual async Task<ActionResult<T>> GetProductById(string Id)
        {
            var product = await _core.Get(Id);

            if (product == null)
            {
                _logger.LogError($"Product with Id: {Id}, not found.");
                return NotFound();
            }

            return Ok(product);
        }

        [HttpGet("{Search}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public virtual async Task<ActionResult<IEnumerable<T>>> Search(string Search)
        {
            var product = await _core.Search(Search);

            if (product == null)
            {
                _logger.LogError($"Product(s) with search string: {Search}, not found.");
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public virtual async Task<ActionResult<T>> Create([FromBody] T obj)
        {
            try
            {
                await _core.Create(obj);
                var id = GetId(obj);
                return CreatedAtAction("GetProductById", new { Id = id }, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] T obj)
        {
            return Ok(await _core.Update(obj));
        }

        [HttpDelete("{Id:length(24)}")]
        public virtual async Task<IActionResult> DeleteById(string Id)
        {
            return Ok(await _core.Delete(Id));
        }

        private BsonValue GetId(T entity)
        {
            var bsonDoc = entity.ToBsonDocument();
            return bsonDoc.GetElement("_id").Value;
        }
    }
}
