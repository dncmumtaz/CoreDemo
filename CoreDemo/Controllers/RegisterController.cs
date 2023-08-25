using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
	public class RegisterController : Controller
	{
		private readonly Context context;
		private readonly WriterManager writerManager;

		public RegisterController( Context context )
		{
			this.context = context;
			writerManager = new WriterManager(new EfWriterRepository(context));
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Index(Writer p)
		{
			WriterValidator validationRules = new WriterValidator();
			ValidationResult validationResult = validationRules.Validate(p);
			if(validationResult.IsValid )
			{
                p.Status = true;
                p.About = "Deneme test";
                p.CreateDate = DateTime.Now;
                writerManager.AddWriter(p);
                return RedirectToAction("Index", "Blog");
            }
			else
			{
				foreach(var item in validationResult.Errors )
				{
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}
			
			return View();
		}
	}
}
