using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
	public class AboutController : Controller
	{
		private Context context;
		private AboutManager aboutManager;

		public AboutController( Context context )
		{
			this.context = context;
			aboutManager = new AboutManager(new EfAboutRepository(context));
		}

		public IActionResult Index()
        {
            var values = aboutManager.GetList();
            return View(values);
		}

		public PartialViewResult SocialMediaAbout()
		{
			return PartialView();
		}
	}
}
