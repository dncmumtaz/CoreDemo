using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private Context context;
        CategoryManager categoryManager;

        public CategoryController( Context dbContext )
        {
            context = dbContext;
            categoryManager = new CategoryManager(new EfCategoryRepository(context));
        }

        public IActionResult Index(int page = 1)
        {
            var values = categoryManager.GetList().ToPagedList(page,2);
            return View(values);
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(Category p)
        {
            CategoryValidator validationRules = new CategoryValidator();
            ValidationResult validationResult = validationRules.Validate(p);
            if ( validationResult.IsValid )
            {
                p.Status = true;
                categoryManager.TAdd(p);
                return RedirectToAction("Index", "Category");
            }
            else
            {
                foreach ( var item in validationResult.Errors )
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }

        public IActionResult DeleteCategory(int id)
        {
            var value = categoryManager.GetById(id);
            categoryManager.TDelete(value);
            return RedirectToAction("Index");
        }
    }
}
