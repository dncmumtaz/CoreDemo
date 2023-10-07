using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{

    public class DashboardController : Controller
    {
        private Context context;

        public DashboardController( Context context )
        {
            this.context = context;
        }

        public IActionResult Index()
        {
			var userName = User.Identity.Name;
			var userMail = context.Writers.Where(x => x.Name == userName).Select(x => x.Email).FirstOrDefault();
            var writerId = context.Writers.Where( x => x.Email == userMail).Select(y => y.Id).FirstOrDefault();
			ViewBag.v1 = context.Blogs.Count().ToString();
            ViewBag.v2 = context.Blogs.Where(x => x.WriterId == writerId).Count().ToString();
            ViewBag.v3 = context.Categories.Count().ToString();
            return View();
        }
    }
}
