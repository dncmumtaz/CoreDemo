using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreDemo.Controllers
{
    public class CategoryController : Controller
    {
        private Context _dbContext;
        CategoryManager categoryManager;

        public CategoryController(Context dbContext )
        {
            _dbContext = dbContext;

            categoryManager = new CategoryManager(new EfCategoryRepository(_dbContext));
        }

        public IActionResult Index()
        {
            var values = categoryManager.GetList();
            return View(values);
        }
    }
}

