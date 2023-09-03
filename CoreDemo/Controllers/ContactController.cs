using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class ContactController : Controller
    {
        private Context context;
        private ContactManager contactManager;

        public ContactController( Context context )
        {
            this.context = context;
            contactManager = new ContactManager(new EfContactRepository(context));
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Contact p)
        {
            p.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.Status = true;
            contactManager.ContactAdd(p);
            return RedirectToAction("Index", "Blog");
        }
    }
}
