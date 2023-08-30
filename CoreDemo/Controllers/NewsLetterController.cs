using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class NewsLetterController : Controller
    {
        private Context context;
        private NewsLetterManager _newsLetterManager;

        public NewsLetterController( Context context )
        {
            this.context = context;
            _newsLetterManager = new NewsLetterManager(new EfNewsLetterRepository(this.context));
        }

        [HttpGet]
        public PartialViewResult SubscribeMail()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult SubscribeMail(NewsLetter p)
        {
            p.Status = true;
            p.CreateDate = DateTime.Now;
            _newsLetterManager.AddNewsLetter(p);
            return PartialView();
        }
    }
}
