using System;
using System.Collections.Generic;
using MongoDB.Driver;
using dabAs3.Models;

namespace dabAs3.Services
{
    public class DummyData
    {
        private readonly IMongoCollection<User> _user;
        private readonly IMongoCollection<Post> _post;
        private readonly IMongoCollection<Comment> _comment;
        private readonly IMongoCollection<Circle> _circle;

        public DummyData()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("DabAssignment3");

            _user = database.GetCollection<User>("Users");
            _post = database.GetCollection<Post>("Posts");
            _comment = database.GetCollection<Comment>("Comments");
            _circle = database.GetCollection<Circle>("Circles");

            UserDummyData(_user);
            PostDummyData(_post);
            CommentDummyData(_comment);
            CircleDummyData(_circle);
        }

        static async void UserDummyData(IMongoCollection<User> user)
        {
            var newUsers = new List<User>
            {
                new User
                {
                    Id          = "100000000000000000000001",
                    Name        = "Mikkel",
                    Gender      = "Male",
                    Age         = 31,
                    BlockList = new List<string>()
                    {
                        "100000000000000000000003"
                    },
                    Followers   = new List<string>
                    {
                        "100000000000000000000002"
                    },
                    Following   = new List<string>
                    {
                        "100000000000000000000002"
                    },
                    Circles     = new List<string>
                    {
                        "400000000000000000000001"
                    },
                },

                new User
                {
                    Id          = "100000000000000000000002",
                    Name        = "Frodi",
                    Gender      = "Male",
                    Age         = 32,
                    BlockList = new List<string>()
                    {
                        "100000000000000000000003"
                    },
                    Followers   = new List<string>
                    {
                        "100000000000000000000001"
                    },
                    Following   = new List<string>
                    {
                        "100000000000000000000001"
                    },
                    Circles     = new List<string>
                    {
                        "400000000000000000000001"
                    },
                },

                new User
                {
                    Id          = "100000000000000000000003",
                    Name        = "Outsider",
                    Gender      = "Male",
                    Age         = 30,
                    BlockList = new List<string>(),
                    Followers   = new List<string>
                    {
                    },
                    Following   = new List<string>
                    {
                        "100000000000000000000001",
                        "100000000000000000000002"
                    },
                    Circles     = new List<string>{},
                },

                new User
                {
                    Id          = "100000000000000000000004",
                    Name        = "Nanna",
                    Gender      = "Feale",
                    Age         = 25,
                    BlockList = new List<string>(),
                    Followers   = new List<string>
                    {
                    },
                    Following   = new List<string>
                    {
                    },
                    Circles     = new List<string>
                    {
                        "400000000000000000000001"
                    },
                }
            };

            await user.InsertManyAsync(newUsers);
        }

        static async void PostDummyData(IMongoCollection<Post> post)
        {
            var newPost = new List<Post>
            {
                new Post
                {
                    Id          = "200000000000000000000001",
                    Author      = "100000000000000000000001",
                    Timestamp   = DateTime.Today,
                    Content     = "Check out the new thing i call FaceSlap",
                    Privacy      = "p",
                    Comments   = new List<string>{
                        "300000000000000000000001",
                        "300000000000000000000002"
                    },
                    Circles     = new List<string>{},
                },

                new Post
                {
                    Id          = "200000000000000000000002",
                    Author      = "100000000000000000000001",
                    Timestamp   = DateTime.Today,
                    Content     = "This is a private post for my followers",
                    Privacy      = "f",
                    Comments   = new List<string>{},
                    Circles     = new List<string>{},
                },

                new Post
                {
                    Id          = "200000000000000000000003",
                    Author      = "100000000000000000000001",
                    Timestamp   = DateTime.Today,
                    Content     = "This is a private post for my school circle",
                    Privacy     = "c",
                    Comments   = new List<string>{},
                    Circles     = new List<string>{
                        "400000000000000000000001"
                    },
                }
            };

            await post.InsertManyAsync(newPost);
            
        }

        static async void CommentDummyData(IMongoCollection<Comment> comment)
        {
              var newComments = new List<Comment>
            {
                new Comment
                {
                    Id          = "300000000000000000000001",
                    Author      = "100000000000000000000002",
                    Timestamp   = DateTime.Today,
                    Content     = "This is going to be huge",
                },

                new Comment
                {
                    Id          = "300000000000000000000002",
                    Author      = "100000000000000000000001",
                    Timestamp   = DateTime.Today,
                    Content     = "I KNOW!!!",
                }
            };

            await comment.InsertManyAsync(newComments);
        }

        static async void CircleDummyData(IMongoCollection<Circle> circle)
        {
            var newCircles = new List<Circle>
            {
                new Circle
                {
                    Id          = "400000000000000000000001",
                    Name        = "School",
                    Users     = new List<string>
                    {
                        "100000000000000000000001",
                        "100000000000000000000002",
                        "100000000000000000000004"
                    },
                },

                new Circle
                {
                    Id          = "400000000000000000000002",
                    Name        = "Work",
                    Users     = new List<string>
                    {
                        "100000000000000000000004"
                    },
                }
            };

            await circle.InsertManyAsync(newCircles);
        }
    }
}