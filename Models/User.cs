using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace dabAs3.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name {get;set;}
        public string Gender {get;set;}
        public int Age {get;set;}

        public List<string> BlockList {get;set;}
        public List<string> Followers {get;set;}
        public List<string> Following {get;set;}
        public List<string> Circle {get;set;}

    }
}