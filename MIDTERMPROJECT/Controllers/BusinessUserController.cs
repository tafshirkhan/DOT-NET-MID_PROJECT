using MIDTERMPROJECT.Models.Dataase;
using MIDTERMPROJECT.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MIDTERMPROJECT.Controllers
{
    public class BusinessUserController : Controller
    {
        // GET: BusinessUser
        public ActionResult CategoryIndex()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetAllCategory()
        {
            friend_finderEntities1 _db = new friend_finderEntities1();
            var allCat = _db.Categories;
            return Json(new { data = allCat }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult InsertCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InsertCategory(CategoryVM categoryVM)
        {
            friend_finderEntities1 _db = new friend_finderEntities1();

            //if (ModelState.IsValid)
            //{
            //    _db.Categories.Add(category);
            //    _db.SaveChanges();

            //    return RedirectToAction("CategoryIndex");
            //}

            Category cat = new Category();
            cat.categoryName = categoryVM.categoryName;

            _db.Categories.Add(cat);
            _db.SaveChanges();
            return RedirectToAction("CategoryIndex");
        }


        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            friend_finderEntities1 _db = new friend_finderEntities1();
            var category = (from n in _db.Categories where n.id == id select n).FirstOrDefault();
            return View(category);
        }

        [HttpPost]
        public ActionResult EditCategory(Category category)
        {
            friend_finderEntities1 _db = new friend_finderEntities1();
            _db.Entry(category).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("CategoryIndex");
            //return Json(new {data = update }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult DeleteCategory(int id)
        {
            friend_finderEntities1 _db = new friend_finderEntities1();
            Category catId = _db.Categories.Where(x => x.id == id).FirstOrDefault<Category>();
            //if (catId == null)
            //{
            //    return Json(new { success = false, message = "Error" });
            //}
            _db.Categories.Remove(catId);
            _db.SaveChanges();
            return Json(new { success = true, message = "Delete Successful" }, JsonRequestBehavior.AllowGet);

        }



        //PRODUCT FUNCTIONALITY //

        public ActionResult ProductIndex()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetAllProduct()
        {
            friend_finderEntities1 _db = new friend_finderEntities1();
            var allPro = _db.Products.ToList();
            return Json(new { data = allPro }, JsonRequestBehavior.AllowGet);
        }


    }
}