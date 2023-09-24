﻿using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using CoreDemo.Models;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class WriterController : Controller
    {

        private readonly Context context;
        private readonly WriterManager writerManager;

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

        [AllowAnonymous]
        [HttpGet]
        public IActionResult WriterEditProfile()
        {
            var values = writerManager.GetById(1);
            return View(values);
        }

        [AllowAnonymous]
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
