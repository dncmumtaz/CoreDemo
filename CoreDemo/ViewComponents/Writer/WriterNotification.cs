using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterNotification : ViewComponent
    {
        private Context context;
        NotificationManager notificationManager;

        public WriterNotification( Context context )
        {
            this.context = context;
            notificationManager = new NotificationManager(new EfNotificationRepository(context));
        }

        public IViewComponentResult Invoke()
        {
            var values = notificationManager.GetList();
            return View(values);
        }
    }
}
