using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

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

        public IActionResult Index(int page = 1)
        {
            var values = categoryManager.GetList().ToPagedList(page,2);
            return View(values);
        }
    }
}
