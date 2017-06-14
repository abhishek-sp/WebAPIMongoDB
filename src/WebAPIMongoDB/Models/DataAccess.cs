using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace WebAPIMongoDB.Models
{
    public class DataAccess
    {
        MongoClient _client;
        MongoServer _server;
        MongoDatabase _db;

        public DataAccess()
        {
            _client = new MongoClient("mongodb://localhost:27017");
            _server = _client.GetServer();
            _db = _server.GetDatabase("test");
        }

        //Products
        public IEnumerable<Product> GetProducts()
        {
            return _db.GetCollection<Product>("Products").FindAll();
        }

        public Product GetProduct(ObjectId id)
        {
            var res = Query<Product>.EQ(p => p.Id, id);
            return _db.GetCollection<Product>("Products").FindOne(res);
        }

        public Product Create(Product p)
        {
            _db.GetCollection<Product>("Products").Save(p);
            return p;
        }

        public void Update(ObjectId id, Product p)
        {
            p.Id = id;
            var res = Query<Product>.EQ(pd => pd.Id, id);
            var operation = Update<Product>.Replace(p);
            _db.GetCollection<Product>("Products").Update(res, operation);
        }
        public void Remove(ObjectId id)
        {
            var res = Query<Product>.EQ(e => e.Id, id);
            var operation = _db.GetCollection<Product>("Products").Remove(res);
        }

        //Users
        public IEnumerable<Users> GetUsers()
        {
            return _db.GetCollection<Users>("Users").FindAll();
        }

        public Users GetUser(ObjectId id)
        {
            var res = Query<Users>.EQ(p => p.Id, id);
            return _db.GetCollection<Users>("Users").FindOne(res);
        }

        public Users Create(Users p)
        {
            _db.GetCollection<Users>("Users").Save(p);
            return p;
        }

        public void Update(ObjectId id, Users p)
        {
            p.Id = id;
            var res = Query<Users>.EQ(pd => pd.Id, id);
            var operation = Update<Users>.Replace(p);
            _db.GetCollection<Users>("Users").Update(res, operation);
        }
        public void RemoveUser(ObjectId id)
        {
            var res = Query<Users>.EQ(e => e.Id, id);
            var operation = _db.GetCollection<Users>("Users").Remove(res);
        }
    }
}
