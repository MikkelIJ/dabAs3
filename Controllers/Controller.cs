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

        public void ShowWall(string userID, string guestId)
        {
            List<Post> userPosts;

            userPosts= _postController.Get().FindAll(p => p.Author.Equals(userID) && p.Public == true);

            foreach(var l in userPosts)
            {
                Console.WriteLine();
                Console.WriteLine(l.Author);
                Console.WriteLine(l.Timestamp.ToString());
                Console.WriteLine(l.Content);
                Console.WriteLine();
            }

        }

        public void ShowFeed(string userID)
        {
            var userCircles =_circleController.Get().Value.FindAll(c => c.Users.Contains(UserID)).ToList();

            // Plausible , not sure about this one
            var allUserPosts = _postController.Get().Value.FindAll(p => p.Author.Equals(UserID) || userCircles.Contains(p.Circle));

            foreach(var post in allUserPosts)
            {
                Console.WriteLine(post.Author);
                Console.WriteLine(post.CreationTime.ToString(dateTimeFormat));
                Console.WriteLine(post.TextContent);
                Console.WriteLine();
            }
        }

        public void CreatePost(string userId, string content, string circle, bool pub)
        {
            List<Circle> circ = _circleController.Get().FindAll(c => c.Name.Equals(circle));

            var post = new Post()
            {
                Author = userId,
                Timestamp = DateTime.Today,
                Content = content,
                Public = pub,
                Circles = circ,
            };

        }

        public void CreateComment(string postId, string comment)
        {
            var post = _postController.Get(postId).Value;

            var comm = new Comment
            {
                Content = comment,
            };

            post.Comments.Add(comm);

            _postController.Update(post.Id, post);

            _commentController.Create(comm);
        }
        

    }

}