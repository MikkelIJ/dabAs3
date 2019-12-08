using System;
using System.Collections.Generic;
using MongoDB.Driver;
using dabAs3.Models;

namespace dabAs3.Services
{
    public class CircleService
    {
        private readonly IMongoCollection <Circle> _circles;

        public CircleService()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("DabAssignment3");

            _circles = database.GetCollection<Circle>("Circles");
        }

        public List<Circle> Get() => _circles.Find(circle => true).ToList();

        public Circle Get(string id) => _circles.Find<Circle>(circle => circle.Id == id).FirstOrDefault();

        public Circle Create(Circle circle)
        {
            _circles.InsertOne(circle);
            return circle;
        }

        public void Update(string id, Circle circle)
        {
            _circles.ReplaceOne(c => c.Id.Equals(id), circle);
        }

        public void AddUser(Circle circle, string userId)
        {
            circle.Users.Add(userId);
            Update(circle.Id, circle);
        }
    }
}