using System;
using System.Collections.Generic;
using dabAs3.Models;
using dabAs3.Services;

namespace dabAs3.Controllers
{
    public class Comment_Controller
    {
        private readonly CommentService _commentService;
        private readonly PostService _postService;

         public Comment_Controller(CommentService commentService, PostService postService)
        {
            _commentService = commentService;
            _postService = postService;
        }

        public List<Comment> Get()
        {
            return _commentService.Get();
        }

        public Comment Get(string Id)
        {
            var comment = _commentService.Get(Id);
            return comment;
        }

        public Comment Create(Comment comment)
        {
            _commentService.Create(comment);
            return comment;
        }

    }
}