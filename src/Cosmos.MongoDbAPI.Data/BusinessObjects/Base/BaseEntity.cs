using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace Cosmos.MongoDbAPI.Data.BusinessObjects.Base
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            this.Id = ObjectId.GenerateNewId().ToString();
        }

        [BsonId]

        [BsonRepresentation(BsonType.ObjectId)]
        [JsonIgnore]
        public string Id { get; set; }=ObjectId.GenerateNewId().ToString();

        private DateTime? createdDate;
        private DateTime? modifiedDate;
        [DataType(DataType.DateTime)]
        [JsonIgnore]
        public DateTime CreatedDate
        {
            get { return createdDate ?? DateTime.UtcNow; }
            set { createdDate = value; }
        }

        [DataType(DataType.DateTime)]
        [JsonIgnore]
        public DateTime? ModifiedDate
        {
            get { return modifiedDate ?? DateTime.UtcNow; }
            set { modifiedDate = value; }
        }

       
    }
}
