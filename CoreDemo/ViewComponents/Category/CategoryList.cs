using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Category
{
	public class CategoryList: ViewComponent
	{
		private Context context;
		readonly CategoryManager categoryManager;

		public CategoryList(Context context)
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
