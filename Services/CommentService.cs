using System;
using System.Collections.Generic;
using MongoDB.Driver;
using dabAs3.Models;

namespace dabAs3.Services
{
    public class CommentService
    {
        private readonly IMongoCollection <Comment> _comments;

        public CommentService()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("SocialNetworkDB");

            _comments = database.GetCollection<Comment>("Comments");
        }

        public List<Comment> Get() => _comments.Find(comment => true).ToList();

        public Comment Get(string id) => _comments.Find<Comment>(comment => comment.Id == id).FirstOrDefault();

        public Comment Create(Comment comment)
        {
            _comments.InsertOne(comment);
            return comment;
        }
    }
}