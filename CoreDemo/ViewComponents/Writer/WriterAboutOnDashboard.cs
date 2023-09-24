using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterAboutOnDashboard: ViewComponent
    {
        private Context context;
        WriterManager writerManager;

        public WriterAboutOnDashboard( Context context )
        {
            this.context = context;
            writerManager = new WriterManager(new EfWriterRepository(context));
        }
        public IViewComponentResult Invoke()
        {
            var userMail = User.Identity.Name;
            var writerId =  context.Writers.Where(x => x.Email == userMail).Select(x => x.Id).FirstOrDefault();
            var values = writerManager.GetWriterById(writerId);
            return View(values);
        }
    }
}
