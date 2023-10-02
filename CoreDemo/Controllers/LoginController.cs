using CoreDemo.Models;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
		private readonly SignInManager<AppUser> _signInManager;
		Context context;

		public LoginController( Context context, SignInManager<AppUser> signInManager )
		{
			this.context = context;
			this._signInManager = signInManager;
		}

        public IActionResult Index()
        {
            return View();
        }

		[HttpPost]
		public async Task<IActionResult> Index( UserSignInModel p )
		{
			if(ModelState.IsValid)
			{
				var result = await _signInManager.PasswordSignInAsync(p.Username, p.Password, false, true);
				if(result.Succeeded)
				{
                    return RedirectToAction("Index", "Dashboard");
                }

                return RedirectToAction("Index", "Login");
            }

			return View();
		}

        #region using claim
        //[HttpPost]
		//public async Task<IActionResult> Index(Writer p)
		//{
		//	var dataValue = context.Writers.FirstOrDefault(x => x.Email == p.Email
		//	&& x.Password == p.Password);

		//	if ( dataValue != null )
		//	{
		//		var claims = new List<Claim>
		//		{
		//			new Claim(ClaimTypes.Name, p.Email)
		//		};
		//		var userIdentity = new ClaimsIdentity(claims, "a");
		//		ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
		//		await HttpContext.SignInAsync(principal);
		//		return RedirectToAction("Index", "Dashboard");
		//	}

		//	return View(); 
		//}
        #endregion

    }
}
