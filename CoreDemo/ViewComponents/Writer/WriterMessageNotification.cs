using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterMessageNotification : ViewComponent
    {
        private Context context;
        private MessageManager messageManager;

        public WriterMessageNotification( Context context )
        {
            this.context = context;
            messageManager = new MessageManager(new EfMessageRepository(context));
        }

        public IViewComponentResult Invoke(  )
        {
            string p;
            p = "mail@mail.com";
            var values = messageManager.GetInboxListByWirter(p);
            return View(values);
        }
    }
}
