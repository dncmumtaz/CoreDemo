using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Blog
{
	public class BlogLast3Post : ViewComponent
	{
		private Context context ;
		private BlogManager blogManager ;

		public BlogLast3Post( Context context )
		{
			this.context = context;
			blogManager = new BlogManager(new EfBlogRepository(context));
		}
		public IViewComponentResult Invoke()
		{
			var values = blogManager.GetLastThreeBlog();
			return View(values);
		}
	}
}
