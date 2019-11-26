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
        [BsonElement("Gender")]
        public string Gender {get;set;}
        [BsonElement("Age")]
        public int Age {get;set;}

        [BsonElement("BlockedList")]   
        public List<string> BlockedList {get;set;}
        [BsonElement("Followers")]
        public List<string> Followers {get;set;}
        [BsonElement("Following")]
        public List<string> Following {get;set;}
        [BsonElement("Circles")]
        public List<string> Circles {get;set;}

        public override string ToString()
        {
            // List to String. mangler at finde en løsning hvor .TrimStart('0') virker for alle tal

            String BlockedString    = String.Join(", ",BlockedList.ToArray());
            String FollowerString   = String.Join(", ",Followers.ToArray()).TrimStart('0');
            String FollowingString  = String.Join(", ",Following.ToArray()).TrimStart('0');
            String CirclesString    = String.Join(", ",Circles.ToArray()).TrimStart('0');



        return string.Format("UserId: ({0}, Name: {1}, Gender: {2}, Age: {3}, Blocked List: {4}, Followers: {5}, Circles: {6}", Id.TrimStart('0'), Name, Gender, Age, BlockedString, FollowerString, CirclesString);
        }

    }
}