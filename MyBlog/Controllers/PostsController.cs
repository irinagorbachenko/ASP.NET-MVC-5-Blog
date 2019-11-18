using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyBlog.DAL;
using MyBlog.Entities.Models;
using MyBlog.Entities.Models.ViewModels;

namespace MyBlog.Controllers

{   //Controller for a Post Model.
    //All references to the database context are replaced by references to the appropriate repository,
    //using UnitOfWork properties to access the repository.The Dispose method disposes the UnitOfWork instance.
   
    public class PostsController : Controller
    {
        UnitOfWork unitOfWork;


        public PostsController()
        {
            unitOfWork = new UnitOfWork();
        }
        public ActionResult Index()
        {
            var posts = unitOfWork.PostRepository.Get(orderBy: q => q.OrderByDescending(d => d.PostDate));
            var poll = unitOfWork.PollRepository.Get().First();

    
            return View(new PostsPoll { Posts = posts, Polls = poll });
        }

        [HttpPost]
        public ActionResult Index(string answer)
        {
            PollOptions pollOptions = unitOfWork.PollOptionsRepository.Get().FirstOrDefault(p => p.Answer == answer);
            pollOptions.Votes++;
            unitOfWork.Save();

            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Post p)
        {
            if (ModelState.IsValid)
            {
                var post = new Post
                {
                    Title = p.Title,
                    AuthorName = p.AuthorName,
                    PostDate = p.PostDate,
                    PostBody = p.PostBody,
                    PostTag=p.PostTag

                };

                unitOfWork.PostRepository.Insert(p);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(p);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = unitOfWork.PostRepository.GetByID(id);
            if (post == null)
            {
                return HttpNotFound();
            }

            return View(post);
        }
       
        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = unitOfWork.PostRepository.GetByID(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = unitOfWork.PostRepository.GetByID(id);
            unitOfWork.PostRepository.Delete(post);
            unitOfWork.Save();


            return RedirectToAction("Index");
        }
    


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

