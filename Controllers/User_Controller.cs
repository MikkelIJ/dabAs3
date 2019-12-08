using System;
using System.Collections.Generic;
using dabAs3.Models;
using dabAs3.Services;

namespace dabAs3.Controllers
{
    public class User_Controller
    {
        private readonly UserService _userService;
        private readonly CircleService _circleService;

         public User_Controller(UserService userService, CircleService circleService)
        {
            _userService = userService;
            _circleService = circleService;
        }

        public List<User> Get()
        {
            return _userService.Get();
        }

        public User Get(string id)
        {
            var user = _userService.Get(id);
            return user;
        }

        // public User getFollowers(string id)
        // {
        //     var user = _userService.
        // }

    }
}