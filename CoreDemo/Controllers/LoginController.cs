using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CoreDemo.Controllers
{
    public class LoginController : Controller
    {
		Context context;

		public LoginController( Context context )
		{
			this.context = context;
		}

		[AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }


		[AllowAnonymous]
        [HttpPost]
		public async Task<IActionResult> Index(Writer p)
		{
			var dataValue = context.Writers.FirstOrDefault(x => x.Email == p.Email
			&& x.Password == p.Password);

			if ( dataValue != null )
			{
				var claims = new List<Claim>
				{
					new Claim(ClaimTypes.Name, p.Email)
				};
				var userIdentity = new ClaimsIdentity(claims, "a");
				ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
				await HttpContext.SignInAsync(principal);
				return RedirectToAction("Index", "Writer");
			}

			return View(); 
		}
	}
}
