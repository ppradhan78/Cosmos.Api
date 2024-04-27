using Azure;
using Azure.Data.Tables;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace Cosmos.TableAPI.Data.SimpleModels
{
    public class OrderDetailsSampleModel 
    {

        public string OrderID { get; set; }
        public string productId { get; set; }
        public decimal unitPrice { get; set; }
        public string quantity { get; set; }
        public Single? discount { get; set; }
        
    }
    public class OrderDetails  : ITableEntity
    {

        public string OrderID { get; set; }
        public string productId { get; set; }
        public decimal unitPrice { get; set; }
        public string quantity { get; set; }
        public Single? discount { get; set; }
        public string PartitionKey { get; set; } = default!;
        public string RowKey { get; set; } = default!;
        public DateTimeOffset? Timestamp { get; set; } = default!;
        public ETag ETag { get; set; } = default!;
    }
}
