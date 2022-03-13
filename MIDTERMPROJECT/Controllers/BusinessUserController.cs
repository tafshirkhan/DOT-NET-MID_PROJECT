
using MIDTERMPROJECT.Models.Dataase;
using MIDTERMPROJECT.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
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
            friend_finderEntities2 _db = new friend_finderEntities2();
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
            friend_finderEntities2 _db = new friend_finderEntities2();

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
            friend_finderEntities2 _db = new friend_finderEntities2();
            var category = (from n in _db.Categories where n.id == id select n).FirstOrDefault();
            return View(category);
        }

        [HttpPost]
        public ActionResult EditCategory(Category category)
        {
            friend_finderEntities2 _db = new friend_finderEntities2();
            _db.Entry(category).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("CategoryIndex");
            //return Json(new {data = update }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult DeleteCategory(int id)
        {
            friend_finderEntities2 _db = new friend_finderEntities2();
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
            friend_finderEntities2 _db = new friend_finderEntities2();
            var allPro = _db.Products.ToList();
            return Json(new { data = allPro }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult InsertNewProducts()
        {
            friend_finderEntities2 _db = new friend_finderEntities2();
            //var product = new ProductDTO();
            //product.ProductTypeMaster = _db.Category.ToList();
            //ViewBag.SubmitValue = "Save";

            List<Category> CategoryList = _db.Categories.OrderBy(a => a.categoryName).ToList();
            ViewBag.CategoryList = new SelectList(CategoryList, "id", "categoryName");
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult InsertNewProducts(NewProductVM productVM)
        {
            friend_finderEntities2 _db = new friend_finderEntities2();

            Product product = new Product();
            product.productName = productVM.productName;
            product.productDescription = productVM.productDescription;
            product.productPrice = productVM.productPrice;
            product.productImage = "STR";
            product.categoryId = productVM.categoryId;

            _db.Products.Add(product);
            _db.SaveChanges();
            return RedirectToAction("ProductIndex");
        }

        //[HttpGet]
        //public ActionResult InsertProduct()
        //{
        //    friend_finderEntities2 _db = new friend_finderEntities2();
        //    List<Category> CategoryList = _db.Categories.OrderBy(a => a.categoryName).ToList();
        //    ViewBag.CategoryList = new SelectList(CategoryList, "id", "categoryName");

        //    //var Category = _db.Categories.ToList();

        //    //ViewBag.CategoryList = new SelectList(Category, "id", "categoryName");
        //    return View();
        //}

        //[HttpPost]
        //[ValidateInput(false)]
        //public ActionResult InsertProduct(ProductVM productVM)
        //{
        //    friend_finderEntities2 _db = new friend_finderEntities2();

        //    //string fileName = Path.GetFileNameWithoutExtension(productVM.ImageFiles.FileName);
        //    //string extension = Path.GetExtension(productVM.ImageFiles.FileName);
        //    //fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
        //    //productVM.productImage = "~/ProductImages/" + fileName;
        //    //fileName = Path.Combine(Server.MapPath("~/ProductImages/"), fileName);
        //    //productVM.ImageFiles.SaveAs(fileName);

        //    //using (friend_finderEntities1 _db = new friend_finderEntities1())
        //    //{
        //    //    _db.Products.Add(productVM);

        //    //}

        //    Product product = new Product();
        //    product.productName = productVM.productName;
        //    product.productDescription = productVM.productDescription;
        //    product.productPrice = productVM.productPrice;
        //    product.productImage = "STR";
        //    //product.id = productVM.CatId;

        //    _db.Products.Add(product);
        //    _db.SaveChanges();

        //    return RedirectToAction("ProductIndex");
        //}


    }
}