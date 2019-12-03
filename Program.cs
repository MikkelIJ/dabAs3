using System;
using System.Collections.Generic;
using dabAs3.Models;
using dabAs3.Service;

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
                        break;

                    case "f":
                        break;

                    case "p":
                        break;

                    case "c":
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
