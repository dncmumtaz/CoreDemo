using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class MessageController : Controller
    {
        private Context context;
        private Message2Manager message2Manager;

        public MessageController( Context context )
        {
            this.context = context;
            message2Manager = new Message2Manager( new EfMessage2Repository(context) );
        }
       
        public IActionResult InBox()
        {
            var values = message2Manager.GetInboxListByWriter(2);
            return View(values);
        }

        public IActionResult MessageDetails( int id )
        {
            CategoryManager categoryManager = new(new EfCategoryRepository(context));
            var values = message2Manager.GetById(id);
            return View(values);
        }
    }
}
