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
            Console.WriteLine("DABAS3!");

            var userService = new UserService();
            List<User> list = userService.Get();
            
            

            foreach(var l in list)
            {
                System.Console.WriteLine(l);
            }
        }
    }
}
