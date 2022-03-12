using MIDTERMPROJECT.Models.Dataase;
using MIDTERMPROJECT.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MIDTERMPROJECT.Controllers
{
    public class AccountController : Controller
    {
        
        // GET: Account
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegistrationVM regVM)
        {
            friend_finderEntities1 _db = new friend_finderEntities1();
            bool UserExist = _db.Users.Any(x => x.Username == regVM.Username);
            if (UserExist)
            {
                ViewBag.UserMessage = "This username is already exist";
                return View();
            }


            //if (ModelState.IsValid)
            //{
            //    _db.Users.Add(regVM.)
            //}

            User user = new User();
            user.Username = regVM.Username;
            user.Password = regVM.Password;
            user.Type = regVM.Type;

            _db.Users.Add(user);
            _db.SaveChanges();
            return RedirectToAction("Index", "Social");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        
        [HttpPost]
        public ActionResult Login(LoginVM logVM)
        {
            friend_finderEntities1 _db = new friend_finderEntities1();
            bool userExist = _db.Users.Any(u => u.Username == logVM.Username
             && u.Password == logVM.Password);
            if (userExist)
            {
                //Session["Id"] = _db.Users.Where(x => x.Username == logVM.Username).FirstOrDefault();
                Session["Id"] = _db.Users.Single(x => x.Username == logVM.Username).Id;

                FormsAuthentication.SetAuthCookie(logVM.Username, false);
                return RedirectToAction("ViewPost","Social");
            }
            //ViewBag.ErrorMessage = "Invalid User";
            TempData["msg"] = "Invalid Credentials";
            return RedirectToAction("Login");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}