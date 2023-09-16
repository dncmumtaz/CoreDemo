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
            var values = writerManager.GetWriterById(1);
            return View(values);
        }
    }
}
