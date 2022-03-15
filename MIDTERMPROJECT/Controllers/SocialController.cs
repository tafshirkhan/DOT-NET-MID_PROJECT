using MIDTERMPROJECT.Models.Dataase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MIDTERMPROJECT.Models.ViewModels;
using System.IO;

namespace MIDTERMPROJECT.Controllers
{
    public class SocialController : Controller
    {
        
        // GET: Social
        [HttpGet]
        public ActionResult PostIndex()
        {
            int userId = Convert.ToInt32(Session["Id"]);
            if (userId == 0)
            {
                return RedirectToAction("Login", "Account");
            }
            return View(new postVM());
        }

        
        [HttpPost]
        public ActionResult PostIndex(Post postVM)
        {
            //friend_finderEntities1 _db = new friend_finderEntities1();


            int userId = Convert.ToInt32(Session["Id"]);
            if (userId == 0)
            {
                return RedirectToAction("Login", "Account");
            }
            string fileName = Path.GetFileNameWithoutExtension(postVM.ImageFile.FileName);
            string extension = Path.GetExtension(postVM.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            postVM.Image = "~/PostedImages/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/PostedImages/"), fileName);
            postVM.ImageFile.SaveAs(fileName);

            //Post post = new Post();
            //post.User_Post = postVM.User_Post;
            //post.CreatedOn = postVM.CreatedOn;
            
            using (friend_finderEntities2 _db = new friend_finderEntities2())
            {
                _db.Posts.Add(postVM);
                _db.SaveChanges();
            }
            ModelState.Clear();

            return View();
        }

        //[HttpPost]
        //public ActionResult AddNewPost(Post postVM)
        //{
        //    var file = postVM.ImageFile;

        //    if (file != null)
        //    {
        //        //var fileName = Path.GetFileName(file.FileName);
        //        //var extension = Path.GetExtension(file.FileName);
        //        //var fileNameWithoutEx = Path.GetFileNameWithoutExtension(file.FileName);
        //        //file.SaveAs(Server.MapPath("/UploadedImage/" + file.FileName));
        //        //model.ImageFile;

        //        string fileName = Path.GetFileNameWithoutExtension(postVM.ImageFile.FileName);
        //        string extension = Path.GetExtension(postVM.ImageFile.FileName);
        //        fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
        //        postVM.Image = "~/UploadedImage/" + fileName;
        //        fileName = Path.Combine(Server.MapPath("~/UploadedImage"), fileName);
        //        postVM.ImageFile.SaveAs(fileName);

        //        using (friend_finderEntities1 _db = new friend_finderEntities1())
        //        {
        //            _db.Posts.Add(postVM);
        //            _db.SaveChanges();
        //        }
        //        ModelState.Clear();


        //    }
        //    return View();
        //    //return Json(postVM, JsonRequestBehavior.AllowGet);
        //    //return RedirectToAction("Register", "Account");
        //}

        
        [HttpGet]
        public ActionResult RetriveImage(int id)
        {
            //friend_finderEntities1 _db = new friend_finderEntities1();
            Post post = new Post();

            using(friend_finderEntities2 _db = new friend_finderEntities2())
            {
                post = _db.Posts.Where(x => x.Id == id).FirstOrDefault(); 
            }           
            return View(post);
        }

        
        
        [HttpGet]
        public ActionResult ViewPost(Post postVM)
        {
            friend_finderEntities2 _db = new friend_finderEntities2();
            int userId = Convert.ToInt32(Session["Id"]);
            if (userId == 0)
            {
                return RedirectToAction("Login", "Account");
            }
            //bool postExist = _db.Posts.Any(u => u.User_Post == postVM.User_Post);
            //if (postExist)
            //{
            //    Session["Id"] = _db.Posts.Single(x => x.User_Post == postVM.User_Post).Id;
            //}

            var allpost = _db.Posts.ToList();
            return View(allpost);
        }

        //[HttpPost]
        //public JsonResult DeletePost(int Id)
        //{
        //    friend_finderEntities2 _db = new friend_finderEntities2();
        //    var data = _db.Posts.Where(x => x.Id == Id).SingleOrDefault();

        //    if(data != null)
        //    {
        //        _db.Posts.Remove(data);
        //        _db.SaveChanges();
        //    }

        //    return Json(data, JsonRequestBehavior.AllowGet);
        //}


        //public ActionResult CommentIndex()
        //{
        //    List<Post> post = new List<Post>();
        //    List<User> user = new List<User>();

        //    return View();

        //}

        
        public ActionResult PostAComment(postCommentVM postCommentVM)
        {
            friend_finderEntities2 _db = new friend_finderEntities2();

            int userId = Convert.ToInt32(Session["Id"]);
            if (userId == 0)
            {
                return RedirectToAction("Login", "Account");
            }
            //var data = (from n in _db.Posts where n.Id == id select n).FirstOrDefault();
            //var post = _db.Posts.ToList();
            Comment comment = new Comment();
            comment.Cmnt = postCommentVM.PostCommentBox;
            comment.Post_id = postCommentVM.PostId;
            comment.User_id = userId;
            comment.CreatedOn = DateTime.Now;
            _db.Comments.Add(comment);
            _db.SaveChanges();

            return RedirectToAction("AllComments");
        }

        
        [HttpGet]
        public ActionResult AllComments()
        {
            friend_finderEntities2 _db = new friend_finderEntities2();
            int userId = Convert.ToInt32(Session["Id"]);
            if (userId == 0)
            {
                return RedirectToAction("Login", "Account");
            }
            var allComments = _db.Comments.Include(x => x.Replies).OrderByDescending(x=>x.CreatedOn).ToList();
            return View(allComments);
        }

        
        [HttpPost]
        public ActionResult ReplyComment(ReplyVM replyVM)
        {
            friend_finderEntities2 _db = new friend_finderEntities2();

            int userId = Convert.ToInt32(Session["Id"]);
            if(userId == 0)
            {
                return RedirectToAction("Login", "Account");
            }
            Reply reply = new Reply();
            reply.Reply_Cmnt = replyVM.ReplyComment;
            reply.Comment_id = replyVM.CommentId;
            reply.User_id = userId;
            reply.CreatedOn = DateTime.Now;

            _db.Replies.Add(reply);
            _db.SaveChanges();
            return RedirectToAction("AllComments");

        }


        
        public ActionResult ViewProfile(int id)
        {
            friend_finderEntities2 _db = new friend_finderEntities2();
            int userId = Convert.ToInt32(Session["Id"]);
            if (userId == 0)
            {
                return RedirectToAction("Login", "Account");
            }
            var uId = (from n in _db.Users where n.Id == id select n).FirstOrDefault();
            return View(uId);
        }
    }
}