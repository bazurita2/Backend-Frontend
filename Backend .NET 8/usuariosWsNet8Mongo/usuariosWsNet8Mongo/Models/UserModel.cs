using MongoDB.Bson.Serialization.Attributes;

namespace usuariosWsNet8Mongo.Models
{
    public class UserModel
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public required string Id { get; set; }
        [BsonElement("name")]
        public string? Name { get; set; }
        [BsonElement("lastname")]
        public string? LastName { get; set; }
        [BsonElement("email")]
        public string? Email { get; set; }
        [BsonElement("password")]
        public string? Password { get; set; }
        [BsonElement("address")]
        public string? Address { get; set; }
    }
}
