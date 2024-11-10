using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project02_MovieWebsite.Models;
using Project02_MovieWebsite.ViewModel;
using System.Web.Helpers;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Project02_MovieWebsite.Identity;

namespace Project02_MovieWebsite.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterVM registerVM)
        {
            if (ModelState.IsValid)
            {
                var appDbContext = new AppDbContext();
                var userStore = new AppUserStore(appDbContext);
                var userManager = new AppUserManager(userStore);
                var PwdHash = Crypto.HashPassword(registerVM.Password);
                var user = new AppUser()
                {
                    Email = registerVM.Email,
                    UserName = registerVM.UserName,
                    PasswordHash = PwdHash,
                };
                IdentityResult identityResult = userManager.Create(user);
                if (identityResult.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Customer");

                    var authenManager = HttpContext.GetOwinContext().Authentication;

                    var userIdentity = userManager.CreateIdentity(user , DefaultAuthenticationTypes.ApplicationCookie);

                    authenManager.SignIn(new AuthenticationProperties(), userIdentity);
                }
                return RedirectToAction("Index", "Home");

            }
            else
            {
                ModelState.AddModelError("New Error", "Invalid Data");
                return View();
            }
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginVM loginVM)
        {
            var appDbContext = new AppDbContext();
            var userStore = new AppUserStore(appDbContext);
            var userManager = new AppUserManager(userStore);

            var user = userManager.Find(loginVM.UserName,loginVM.Password);
            if (user != null)
            {
                var authenManager = HttpContext.GetOwinContext().Authentication;

                var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                authenManager.SignIn(new AuthenticationProperties(), userIdentity);
                return RedirectToAction("Index", "Home");

            }
            else
            {
                ModelState.AddModelError("My Error", "Invalid Username or password");
                return View();
            }
        }
        public ActionResult Logout()
        {
            var authenManager = HttpContext.GetOwinContext().Authentication;
            authenManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}