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
            var values = blogManager.GetBlogListWithCategory();
            return View(values);
        }

        public IActionResult BlogReadAll(int id)
        {
            var values = blogManager.GetBlogById(id);
            return View(values);
        }
    }
}
