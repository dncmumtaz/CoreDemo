using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterMessageNotification : ViewComponent
    {
        private Context context;
        private Message2Manager message2Manager;

        public WriterMessageNotification( Context context )
        {
            this.context = context;
            message2Manager = new Message2Manager(new EfMessage2Repository(context));
        }

        public IViewComponentResult Invoke(  )
        {   
            var values = message2Manager.GetInboxListByWriter(2);
            return View(values);
        }
    }
}
