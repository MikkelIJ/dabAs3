using System;
using System.Collections.Generic;
using dabAs3.Models;
using dabAs3.Services;

namespace dabAs3.Controllers
{
    public class Post_Controller
    {
        private readonly PostService _postService;
        private readonly CommentService _commentService;

         public Post_Controller(PostService postService, CommentService commentService)
        {
            _postService = postService;
            _commentService = commentService;
        }

        public List<Post> Get()
        {
            return _postService.Get();
        }

        public Post Get(string Id)
        {
            var post = _postService.Get(Id);
            return post;
        }

        public Post Create(Post post)
        {
            _postService.Create(post);
            return post;
        }

    }
}