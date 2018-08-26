using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace AspNetCoreMongoDB.Models
{
    public class Customer
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public string Nome { get; set; }

        public string Profissao { get; set; }

        public List<string> Tags { get; set; }
    }
}
