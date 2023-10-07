using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using CoreDemo.Models;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;

namespace CoreDemo.Controllers
{
    public class WriterController : Controller
    {

        private readonly Context context;
        private readonly WriterManager writerManager;
        private readonly UserManager<AppUser> userManager;

        public WriterController( Context context )
        {
            this.context = context;
            writerManager = new WriterManager(new EfWriterRepository(context));
        }

        [Authorize]
        public IActionResult Index()
        {
            var userName = User.Identity.Name;
            ViewBag.UserName = userName;
            return View();
        }

        public IActionResult WriterProfile()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Test()
        {
            return View();
        }

        [AllowAnonymous]
        public PartialViewResult WriterNavBarPartial()
        {
            return PartialView();
        }

        [AllowAnonymous]
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }

        [HttpGet]
        public IActionResult WriterEditProfile()
        {
            var userName = User.Identity.Name;
            var userMail = context.Users.Where(x =>  x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerId = context.Writers.Where(x => x.Email == userMail).Select(x => x.Id).FirstOrDefault();
            var values = writerManager.GetById(writerId);
            return View(values);
        }

        [HttpPost]
        public IActionResult WriterEditProfile( Writer p )
        {
            WriterValidator validationRules = new WriterValidator();
            ValidationResult result = validationRules.Validate(p);

            if ( result.IsValid )
            {
                p.Status = true;
                p.Id = 1;
                p.Image = "asdf";
                writerManager.TUpdate(p);
                return RedirectToAction( "Index", "Dashboard");
            }
            foreach ( var item in result.Errors )
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }

            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult WriterAdd()
        {
            return View();
        }


        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterAdd(AddProfileImage p)
        {
            Writer writer = new Writer();
            if(p.Image != null )
            {
                var extension = Path.GetExtension(p.Image.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newImageName);
                var stream = new FileStream(location, FileMode.Create);
                p.Image.CopyTo(stream);
                writer.Image = newImageName;
            }
            writer.Email = p.Email;
            writer.Name = p.Name;
            writer.Password = p.Password;
            writer.Status = true;
            writer.About = p.About;

            writerManager.TAdd(writer);
            return RedirectToAction("Index", "Dashboard");
        }
    }
}
