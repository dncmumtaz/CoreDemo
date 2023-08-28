using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Blog
{
	public class WriterLastBlog: ViewComponent
	{
		private Context context;
		readonly BlogManager blogManager;

		public WriterLastBlog( Context context )
		{
			this.context = context;
			blogManager = new BlogManager(new EfBlogRepository(context));
		}
		public IViewComponentResult Invoke()
		{
			var values = blogManager.GetBlogListByWriter(1);
			return View(values);
		}
	}
}
