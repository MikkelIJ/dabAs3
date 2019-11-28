using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace dabAs3.Models
{
    public class Post
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Author")]
        public string Author {get;set;}
        [BsonElement("Timestamp")]
        public DateTime Timestamp {get;set;}
        [BsonElement("Content")]
        public string Content {get;set;}
        [BsonElement("Public")]
        public bool Public {get;set;}
        [BsonElement("Comments")]
        public List<string> Comments {get;set;}
        [BsonElement("Circles")]
        public List<string> Circles {get;set;}

    }
}