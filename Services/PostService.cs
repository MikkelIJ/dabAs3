using System;
using System.Collections.Generic;
using MongoDB.Driver;
using dabAs3.Models;

namespace dabAs3.Services
{
    public class PostService
    {
        private readonly IMongoCollection <Post> _posts;

        public PostService()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("DabAssignment3");

            _posts = database.GetCollection<Post>("Posts");
        }

        public List<Post> Get() => _posts.Find(post => true).ToList();

        public Post Get(string id) => _posts.Find<Post>(post => post.Id == id).FirstOrDefault();

        public Post Create(Post post)
        {
            _posts.InsertOne(post);
            return post;
        }

        // public List<Post> GetPostssdfsadfsa() {
        //     _posts.Find()
        // }
    }
}