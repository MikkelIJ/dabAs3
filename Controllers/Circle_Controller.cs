using System;
using System.Collections.Generic;
using dabAs3.Models;
using dabAs3.Services;

namespace dabAs3.Controllers
{
    public class Circle_Controller
    {
        private readonly CircleService _circleService;
        private readonly UserService _userService;
        private readonly PostService _postService;

         public Circle_Controller(CircleService circleService, UserService userService, PostService postService)
        {
            _circleService = circleService;
            _userService = userService;
            _postService = postService;
        }

        public List<Circle> Get()
        {
            return _circleService.Get();
        }
        

        public Circle Get(string Id)
        {
            var circle = _circleService.Get(Id);
            return circle;
        }

        public Circle Create(Circle circle)
        {
            _circleService.Create(circle);
            
            return circle;
        }

        public void Update(string Id, Circle circleIn)
        {
            var circle = _circleService.Get(Id);
            _circleService.Update(Id, circleIn);
        }
    }
}