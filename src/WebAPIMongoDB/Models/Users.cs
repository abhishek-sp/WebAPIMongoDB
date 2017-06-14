using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebAPIMongoDB.Models
{
    public class Users
    {
        public ObjectId Id { get; set; }
        [BsonElement("userId")]
        public int userId { get; set; }
        [BsonElement("name")]
        public string name { get; set; }
        [BsonElement("email")]
        public string email { get; set; }
        [BsonElement("address")]
        public string address { get; set; }
        [BsonElement("iScore")]
        public int iScore { get; set; }
    }
}
