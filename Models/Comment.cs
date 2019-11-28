using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace dabAs3.Models
{
    public class Comment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Author")]
        public string Author {get;set;}
        [BsonElement("Content")]
        public string Content {get;set;}
        [BsonElement("Timestamp")]
        public DateTime Timestamp {get;set;}

    }
}