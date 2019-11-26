using System;
using System.Collections.Generic;
using MongoDB.Driver;
using dabAs3.Models;

namespace dabAs3.Service
{
    public class FeedService
    {
        private readonly IMongoCollection <Feed> _feeds;

        public FeedService()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("SocialNetworkDB");

            _feeds = database.GetCollection<Feed>("Feeds");
        }

        public List<Feed> Get() => _feeds.Find(feed => true).ToList();

        public Feed Get(string id) => _feeds.Find<Feed>(feed => feed.Id == id).FirstOrDefault();

        public Feed Create(Feed feed)
        {
            _feeds.InsertOne(feed);
            return feed;
        }
    }
}