using Azure;
using Azure.Data.Tables;
using Cosmos.TableAPI.Data.BusinessObject;
using Cosmos.TableAPI.Data.SimpleModels;
using System.Collections.Concurrent;

namespace Cosmos.TableAPI.Data.BusinessObjects
{
    public class OrderBo : IOrderBo
    {
        private readonly IConfigurationSettings _configuration;
        private readonly string CosmosDbTableName = "OrderDetails";

        public OrderBo(IConfigurationSettings configuration)
        {
            _configuration = configuration;
        }

        public Task<int> AddRecord(OrderDetailsSampleModel order)
        {
            try
            {
                var client = CosmosTableClientClient();
                var orderdetails = new OrderDetails
                {
                    OrderID= order.OrderID,
                    discount = order.discount,
                    productId = order.productId,
                    quantity = order.quantity,
                    unitPrice = order.unitPrice,
                    PartitionKey= order.productId,
                    //RowKey=Guid.NewGuid().ToString(),
                    RowKey = order.OrderID,
                    Timestamp = DateTime.Now
                };
                var response = client.AddEntity<OrderDetails>(orderdetails);
                return Task.FromResult(response.Status);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<OrderDetailsSampleModel> GetAll()
        {
            var output = new List<OrderDetailsSampleModel>();
            try
            {
                var client = CosmosTableClientClient();
                //var result = client.Query<OrderDetails>(x => x.PartitionKey == PartitionKey);
                var result = client.Query<OrderDetails>();
                // Iterate the <see cref="Pageable"> to access all queried entities.
                foreach (var item in result)
                {
                    output.Add(new OrderDetailsSampleModel()
                    {
                        discount = item.discount,
                        productId = item.productId,
                        quantity = item.quantity,
                        unitPrice = item.unitPrice,
                        OrderID = item.OrderID

                    });
                }
                return output;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task< OrderDetailsSampleModel> GetById(string RowKey, string partitionKey)
        {
            try
            {
                var output = new OrderDetailsSampleModel();
                var tableClient = CosmosTableClientClient();
                var result = await tableClient.GetEntityAsync<OrderDetails>(partitionKey, RowKey);
                
                output.unitPrice = result.Value.unitPrice;
                output.OrderID = result.Value.OrderID;
                output.productId = result.Value.productId;
                output.discount = result.Value.discount;
                output.quantity = result.Value.quantity;

                return output;

            }
            catch (Exception ex)
            {

                throw;
            }
        }
      
        public Task DeleteAsync(string RowKey, string partitionKey)
        {
            try
            {
                var client = CosmosTableClientClient();
                var response = client.DeleteEntity(partitionKey, RowKey);
                return Task.FromResult(response.Status);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<int> UpdateRecord(OrderDetailsSampleModel order, string RowKey, string partitionKey)
        {
            try
            {
                var client = CosmosTableClientClient();
                var result = await client.GetEntityAsync<OrderDetails>( partitionKey, RowKey);

                result.Value.unitPrice = order.unitPrice;
                result.Value.productId = order.productId;
                result.Value.discount = order.discount;
                result.Value.quantity = order.quantity;

                var response = client.UpsertEntity<OrderDetails>(result);
                return response.Status;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
       
        private TableClient CosmosTableClientClient()
        {
            // New instance of the TableClient class
            TableServiceClient tableServiceClient = new TableServiceClient(_configuration.ConnectionStringSetting);
            // New instance of TableClient class referencing the server-side table
            TableClient tableClient = tableServiceClient.GetTableClient(
                tableName: CosmosDbTableName
            ); ;

            return tableClient;
        }

         
    }
}
