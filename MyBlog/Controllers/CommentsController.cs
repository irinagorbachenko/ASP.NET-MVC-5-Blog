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

namespace MyBlog.Controllers

{    //Controller for a Comment Model.
    //All references to the database context are replaced by references to the appropriate repository,
    //using UnitOfWork properties to access the repository.The Dispose method disposes the UnitOfWork instance.

    public class CommentsController : Controller
    {
       
            UnitOfWork unitOfWork;


            public CommentsController()
            {
                unitOfWork = new UnitOfWork();
            }
            public ActionResult Index()
            {
                var comments = unitOfWork.CommentRepository.Get(orderBy: q => q.OrderByDescending(d => d.CommentDate));

                return View(comments);
            }

            public ActionResult Create()
            {
                return View();
            }

            [HttpPost]
            public ActionResult Create(Comment p)
            {
                if (ModelState.IsValid)
                {
                    var comment = new Comment
                    {
                        PostID = p.PostID,
                        CommentAuthorName = p.CommentAuthorName,
                        CommentDate = p.CommentDate,
                        CommentBody = p.CommentBody

                    };

                    unitOfWork.CommentRepository.Insert(p);
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
                Comment comment = unitOfWork.CommentRepository.GetByID(id);
                if (comment == null)
                {
                    return HttpNotFound();
                }

                return View(comment);
            }

            public ActionResult Delete(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Comment comment = unitOfWork.CommentRepository.GetByID(id);
                if (comment == null)
                {
                    return HttpNotFound();
                }
                return View(comment);
            }
    

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
            {
                Comment comment = unitOfWork.CommentRepository.GetByID(id);
                unitOfWork.CommentRepository.Delete(comment);
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
