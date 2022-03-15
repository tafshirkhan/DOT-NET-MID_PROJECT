using MIDTERMPROJECT.Models.Dataase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MIDTERMPROJECT.Controllers
{
    public class PurchaseController : Controller
    {
        // GET: Purchase
        [HttpGet]
        [ValidateInput(false)]
        public ActionResult PurchaseIndex(Product product)
        {
            friend_finderEntities2 _db = new friend_finderEntities2();
            int userId = Convert.ToInt32(Session["Id"]);
            if (userId == 0)
            {
                return RedirectToAction("Login", "Account");
            }
            var allpro = _db.Products.ToList();
            return View(allpro);

            
        }

        
    }
}