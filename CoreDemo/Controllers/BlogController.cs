using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace CoreDemo.Controllers
{

    public class BlogController : Controller
    {
        private Context context;
        BlogManager blogManager;

        public BlogController( Context dbContext )
        {
            this.context = dbContext;
            blogManager = new BlogManager(new EfBlogRepository(context));
        }

        public IActionResult Index()
        {
            var values = blogManager.GetBlogListWithCategory();
            return View(values);
        }

        public IActionResult BlogReadAll( int id )
        {
            ViewBag.i = id;
            var values = blogManager.GetBlogById(id);
            return View(values);
        }

        public IActionResult BlogListByWriter()
        {
            var userMail = User.Identity.Name;
            var writerId = context.Writers.Where(x => x.Email == userMail).Select(x => x.Id).FirstOrDefault();
            var values = blogManager.GetListWithCategoryByWriterBM(writerId);
            return View(values);
        }

        [HttpGet]
        public IActionResult BlogAdd()
        {
            CategoryManager categoryManager = new(new EfCategoryRepository(context));
            List<SelectListItem> categoryValues = (from x in categoryManager.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Name,
                                                       Value = x.Id.ToString(),
                                                   }).ToList();
            ViewBag.cv = categoryValues;
            return View();
        }

        [HttpPost]
        public IActionResult BlogAdd( Blog p )
        {
            var userMail = User.Identity.Name;
            var writerId = context.Writers.Where(x => x.Email == userMail).Select(x => x.Id).FirstOrDefault();
            BlogValidator validationRules = new BlogValidator();
            ValidationResult validationResult = validationRules.Validate(p);
            if ( validationResult.IsValid )
            {
                p.Status = true;
                p.Id = writerId;
                blogManager.TAdd(p);
                return RedirectToAction("BlogListByWriter", "Blog");
            }
            else
            {
                foreach ( var item in validationResult.Errors )
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }

        public IActionResult DeleteBlog( int id )
        {
            var blog = blogManager.GetById(id);
            blogManager.TDelete(blog);
            return RedirectToAction("BlogListByWriter");
        }

        [HttpGet]
        public IActionResult EditBlog( int id )
        {
            CategoryManager categoryManager = new(new EfCategoryRepository(context));
            List<SelectListItem> categoryValues = (from x in categoryManager.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Name,
                                                       Value = x.Id.ToString(),
                                                   }).ToList();
            ViewBag.cv = categoryValues;
            var blog = blogManager.GetById(id);
            return View(blog);
        }

        [HttpPost]
        public IActionResult EditBlog( Blog p )
        {
            var userMail = User.Identity.Name;
            var writerId = context.Writers.Where(x => x.Email == userMail).Select(x => x.Id).FirstOrDefault();
            p.Id = writerId;
            blogManager.TUpdate(p);
            return RedirectToAction("BlogListByWriter");
        }

    }
}
