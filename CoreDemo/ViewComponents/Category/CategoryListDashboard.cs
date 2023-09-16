using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Category
{
    public class CategoryListDashboard : ViewComponent
    {
        private Context context;
        readonly CategoryManager categoryManager;

        public CategoryListDashboard( Context context )
        {
            this.context = context;
            categoryManager = new CategoryManager(new EfCategoryRepository(this.context));
        }

        public IViewComponentResult Invoke()
        {
            var values = categoryManager.GetList();
            return View(values);
        }
    }
}
