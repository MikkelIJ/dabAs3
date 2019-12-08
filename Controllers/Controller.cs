using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using dabAs3.Services;
using dabAs3.Models;
using System.Collections.ObjectModel;

namespace dabAs3.Controllers
{
    public class Controller
    {
        private readonly User_Controller _userController;
        private readonly Post_Controller _postController;
        private readonly Circle_Controller _circleController;
        private readonly Comment_Controller _commentController;

        public Controller()
        {
            _userController = new User_Controller(new UserService(), new CircleService());
            _postController = new Post_Controller(new PostService(), new CommentService());
            _circleController = new Circle_Controller(new CircleService(), new UserService(), new PostService());
            _commentController = new Comment_Controller(new CommentService(), new PostService());
        }

        public void ShowWall(string userID, string guestID)
        {
            List<User> user = _userController.Get().FindAll(u => u.Id.Contains(userID));
            List<User> guest = _userController.Get().FindAll(u => u.Id.Contains(guestID));
            List<Circle> circle =_circleController.Get().Where(c => c.Users.Contains(userID) 
                    && c.Users.Contains(guestID)).ToList();
            
            if(user.Any(u => u.BlockList.Contains(guestID)))
            {
                Console.WriteLine("Guest is blocked by user");
            }
            else
            {
                Console.WriteLine("Guest has access to public posts from user");
                List<Post> publicPosts = _postController.Get().FindAll(f => f.Author.Equals(userID) 
                    && (f.Privacy == "p"));
                
                foreach(var l in publicPosts)
                {
                    Console.WriteLine();
                    Console.WriteLine("Post");
                    Console.WriteLine(l.Timestamp.ToString());
                    Console.WriteLine(l.Content);
                }
            }

            if(user.Any(u => u.Followers.Contains(guestID)))
            {
                Console.WriteLine("Guest follows user");
                List<Post> followersPosts = _postController.Get().FindAll(f => f.Author.Equals(userID) 
                    && (f.Privacy == "p" || f.Privacy == "f"));

                foreach(var l in followersPosts)
                {
                    Console.WriteLine();
                    Console.WriteLine("Post");
                    Console.WriteLine(l.Timestamp.ToString());
                    Console.WriteLine(l.Content);
                }

            }

            if(circle.Any())
            {
                //List<Post> circlePosts = _postController.Get().Where(c => c.Circles.Contains(circle.ID));
                // Console.Write("User and guest are both part of circle ");
                // Console.WriteLine(circleID);
            }

        }

        public void ShowFeed(string userID)
        {
            List<User> user = _userController.Get().FindAll(u => u.Id.Contains(userID));
            List<Post> userPosts = _postController.Get().FindAll(up => up.Author.Equals(userID));
            List<Post> publicPosts = _postController.Get().FindAll(p => p.Privacy == "p");
            //List<Post> followersPosts = _postController.Get().FindAll(Filter by followers (not solved))
            //List<Post> circlePosts = _postController.Get().FindAll(Filter by corcles (not solved))

            foreach(var l in userPosts)
            {
                Console.WriteLine();
                Console.WriteLine("User post:");
                Console.WriteLine(l.Timestamp.ToString());
                Console.WriteLine(l.Content);
            }

            foreach(var l in publicPosts)
            {
                Console.WriteLine();
                Console.WriteLine("Public post:");
                Console.WriteLine(l.Author);
                Console.WriteLine(l.Timestamp.ToString());
                Console.WriteLine(l.Content);
            }
            

            // Plausible , not sure about this one
            //var allUserPosts = _postController.Get().Value.FindAll(p => p.Author.Equals(UserID) || userCircles.Contains(p.Circle));

            // foreach(var post in allUserPosts)
            // {
            //     Console.WriteLine(post.Author);
            //     Console.WriteLine(post.CreationTime.ToString(dateTimeFormat));
            //     Console.WriteLine(post.TextContent);
            //     Console.WriteLine();
            // }
        }

        public void CreatePost(string userId, string content, string circle, string pub)
        {
            //var circ = _circleController.Get(circle);

            var post = new Post()
            {
                Author = userId,
                Timestamp = DateTime.Today,
                Content = content,
                Privacy = pub,
                //Circles = circle,
            };
            _postController.Create(post);
            //post.Circles.Add(circle);
        }

        public void CreateComment(string postId, string commentOwner, string comment)
        {
            var post = _postController.Get(postId);

            var comm = new Comment
            {
                Author = commentOwner,
                Content = comment,
            };

            //post.Comments.Add(comm.Id);

            //_postController.Update(post.Id, post);

            _commentController.Create(comm);
        }
        

    }

}