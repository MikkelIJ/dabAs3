using System;
using System.Collections.Generic;
using MongoDB.Driver;
using dabAs3.Models;

namespace dabAs3.Service
{
    public class UserService
    {
        private readonly IMongoCollection <User> _users;

        public UserService()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("SocialNetworkDB");

            _users = database.GetCollection<User>("Users");
        }

        public List<User> Get() => _users.Find(user => true).ToList();

        public User Get(string id) => _users.Find<User>(user => user.Id == id).FirstOrDefault();

        public User Create(User user)
        {
            _users.InsertOne(user);
            return user;
        }
    }
}