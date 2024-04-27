using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace Cosmos.NoSqlAPI.Data.SimpleModels
{
    public class OrderDetailsSampleModel
    {
        [Key]
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        public string productId { get; set; }
        public decimal unitPrice { get; set; }
        public string quantity { get; set; }
        public Single? discount { get; set; }
    }
}
