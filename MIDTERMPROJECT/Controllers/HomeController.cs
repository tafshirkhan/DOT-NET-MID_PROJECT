using MIDTERMPROJECT.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MIDTERMPROJECT.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Session["Id"] = 0;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult InnerView()
        {
            //Session["Id"] = 0;
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult SideMenuBar()
        {
            List<SideMenuItemVM> list = new List<SideMenuItemVM>();
            //int userId = Convert.ToInt32(Session["Id"]);
            //if (userId == 0)
            //{
            //    //return RedirectToAction("Login", "Account");
            //    list.Add(new SideMenuItemVM { Link = "/Account/Register", LinkName = "Register" });
            //    list.Add(new SideMenuItemVM { Link = "/Account/Login", LinkName = "Login" });
            //}

            //list.Add(new SideMenuItemVM { Link = "/Account/Register", LinkName = "Register" });
            //list.Add(new SideMenuItemVM { Link = "/Account/Login", LinkName = "Login" });

            list.Add(new SideMenuItemVM { Link = "/BusinessUser/CategoryIndex", LinkName = "All Category" });
            list.Add(new SideMenuItemVM { Link = "/BusinessUser/ProductIndex", LinkName = "All Product" });
            list.Add(new SideMenuItemVM { Link = "/Social/PostIndex", LinkName = "Add New Post" });
            list.Add(new SideMenuItemVM { Link = "/Social/AllComments", LinkName = "Explore All the Post" });
            list.Add(new SideMenuItemVM { Link = "/Social/ViewPost", LinkName = "Post a Comment" });


            return PartialView("SideMenuBar", list);
        }


        public ActionResult SideBarBeforeLoginView()
        {
            List<SideBarBeforeLoginVM> list = new List<SideBarBeforeLoginVM>();
            list.Add(new SideBarBeforeLoginVM { Link = "/Account/Register", LinkName = "Register" });
            list.Add(new SideBarBeforeLoginVM { Link = "/Account/Login", LinkName = "Login" });
            return PartialView("SideBarBeforeLoginView",list);
        }
    }
}