using System;
using System.Collections.Generic;
using dabAs3.Models;
using dabAs3.Services;
using dabAs3.Controllers;

namespace dabAs3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("DABAS3!\n\n");
            Console.WriteLine("Do you want to seed the database with sample data? (y/n)\n");

            var seedingChoice = Console.ReadLine();
            if(seedingChoice == "y")
            {
                Console.WriteLine("Seeding database with sample data\n\n");
                DummyData dummy_data = new DummyData();
            }

            do
            {
                Console.WriteLine("Welcome to FaceSlap\n\n"
                + "Press w for wall\n"
                + "Press f for feed\n"
                + "Press p to create a new post\n"
                + "Press c to create a new comment\n"
                + "Press x to quit FaceSlap\n");

                var userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "w":
                        var wall = new Controller();
                        Console.WriteLine("Enter user ID");
                        var userID = Console.ReadLine();
                        Console.WriteLine("Enter guest ID");
                        var guestID = Console.ReadLine();
                        wall.ShowWall(userID, guestID);
                        break;

                    case "f":
                        var feed = new Controller();
                        Console.WriteLine("Enter user ID");
                        var userID_feed = Console.ReadLine();
                        feed.ShowFeed(userID_feed);
                        break;

                    case "p":
                        var newPost = new Controller();
                        Console.WriteLine("Enter Author of new post");
                        var OwnerID = Console.ReadLine();
                        Console.WriteLine("Enter post content");
                        var Content = Console.ReadLine();
                        Console.WriteLine("Add post to circle");
                        string Circle = Console.ReadLine();
                        Console.WriteLine("Want to make the post public? (y/n");
                        string pubSel = Console.ReadLine();
                        bool pub;
                        if(pubSel == "y"){
                            pub = true;
                        }
                        else{
                            pub = false;
                        }
                        newPost.CreatePost(OwnerID, Content, Circle, pub);
                        break;

                    case "c":
                        var newComment = new Controller();
                        Console.WriteLine("Enter post ID");
                        var PostID = Console.ReadLine();
                        Console.WriteLine("Enter Comment");
                        var Comment = Console.ReadLine();
                        newComment.CreateComment(PostID, Comment);
                        break;

                    case "x":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Unknown command!\n\n");
                        break;
                }
            }
            while(true);
        }
    }
}
