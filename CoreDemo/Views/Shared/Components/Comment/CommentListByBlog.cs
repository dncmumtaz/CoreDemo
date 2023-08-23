﻿using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Views.Shared.Components.Comment
{
    public class CommentListByBlog : ViewComponent
    {
        private Context _dbContext;
        CommentManager commentManager;
        public CommentListByBlog(Context dbContext )
        {
            _dbContext = dbContext;
            commentManager = new CommentManager(new EfCommentRepository(_dbContext));

        }
        public IViewComponentResult Invoke()
        {
            var values = commentManager.GetList(4);
            return View(values);
        }
    }
}