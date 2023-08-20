using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class BlogController : Controller
    {
        private Context _dbContext;
        BlogManager blogManager;

        public BlogController(Context dbContext)
        {
            _dbContext = dbContext;
            blogManager = new BlogManager(new EfBlogRepository(_dbContext));
        }
        
        public IActionResult Index()
        {
            var values = blogManager.GetList();
            return View(values);
        }
    }
}
