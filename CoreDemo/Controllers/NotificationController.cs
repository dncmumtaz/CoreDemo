using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class NotificationController : Controller
    {
        private Context _dbContext;
        private NotificationManager notificationManager;

        public NotificationController( Context context )
        {
            _dbContext = context;
            notificationManager = new NotificationManager(new EfNotificationRepository(context));
        }

        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult AllNotifications()
        {
            var values = notificationManager.GetList();
            return View(values);
        }
    }
}
