using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private Context _dbContext;
        CategoryManager categoryManager;

        public CategoryController( Context dbContext )
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
