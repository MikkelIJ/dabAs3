using System;
using System.Collections.Generic;
using MongoDB.Driver;
using System.Threading.Tasks;
using dabAs3.Models;

namespace dabAs3.Services
{
    public class UserService
    {
        private readonly IMongoCollection <User> _users;

        public UserService()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("DabAssignment3");

            _users = database.GetCollection<User>("Users");
        }

        public List<User> Get() => _users.Find(user => true).ToList();

        // public List<User> followingUser(string id)
        // {
        //     var filter = new BsonDocument("Followers",id);
        //     _users.Find()
        // }

        public User Get(string id) => _users.Find<User>(user => user.Id == id).FirstOrDefault();

        public User Create(User user)
        {
            _users.InsertOne(user);
            return user;
        }
    }
}