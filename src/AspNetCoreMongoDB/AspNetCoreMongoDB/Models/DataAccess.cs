using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AspNetCoreMongoDB.Models
{
    public class DataAccess
    {
        private MongoClient _client;
        private IMongoDatabase _db;

        public DataAccess()
        {
            _client = new MongoClient("mongodb://usuario:senha@host:porta/nome_do_banco");
            _db = _client.GetDatabase("nome_do_banco");
        }

        public long CountCustomers() => _db.GetCollection<Customer>(typeof(Customer).Name).CountDocuments(new FilterDefinitionBuilder<Customer>().Empty);

        public IEnumerable<Customer> GetCustomers(string query)
        {
            var tags = query.ToUpper().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var filter = Builders<Customer>.Filter.All(c => c.Tags, tags);
            return _db.GetCollection<Customer>(typeof(Customer).Name).Find(filter).ToList();
        }
    }
}
