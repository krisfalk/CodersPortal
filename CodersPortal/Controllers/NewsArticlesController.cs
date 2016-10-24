using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CodersPortal.Models;
using Newtonsoft.Json;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;

namespace CodersPortal.Controllers
{
    public class NewsArticlesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        

        public void SaveArticles(List<NewsArticle> myArticles)
        {
            for (int i = 0; i < myArticles.Count; i++)
            {
                bool trigger = true;
                foreach(var item in db.NewsArticles)
                {
                    if (item.Article == myArticles[i].Article)
                        trigger = false;
                }
                if (trigger)
                {
                    db.NewsArticles.Add(myArticles[i]);
                    db.SaveChanges();
                }
                trigger = true;
            }
        }
        public ActionResult SaveComments(Comment comment)
        {
            comment.postDate = DateTime.Now;
            db.Comments.Add(comment);
            db.SaveChanges();
            return RedirectToAction("Index", "NewsArticles");
        }

        // GET: NewsArticles
        public ActionResult Index()
        {
            List<NewsArticle> allArticles = new List<NewsArticle>();
            foreach(var item in db.NewsArticles)
            {
                allArticles.Add(item);
            }
            allArticles.Reverse();
            var model = new IndexViewModel
            {
                allDbArticles = allArticles
            };
            return View(model);
        }

        // GET: NewsArticles/Details/5
        public ActionResult Details(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //NewsArticle newsArticle = db.NewsArticles.Find(id);
            //if (newsArticle == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(newsArticle);
            ApplicationUser currentUser = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

            List<Comment> storiesComments = new List<Comment>();
            NewsArticle current = db.NewsArticles.Where(x => x.NewsArticleId == id).Select(x => x).SingleOrDefault();
            foreach(var item in db.Comments)
            {
                if (item.NewsArticleId == current.NewsArticleId)
                {
                    storiesComments.Add(item);
                }
            }
            var model = new IndexViewModel
            {
                singleArticle = current,
                commentList = storiesComments,
                UserName = currentUser.firstName + " " + currentUser.lastName
            };
            return View(model);
        }

        // GET: NewsArticles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NewsArticles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NewsArticleId,Author,Title,Article,ImageUrl,OriginalUrl,PublishDate")] NewsArticle newsArticle)
        {
            if (ModelState.IsValid)
            {
                db.NewsArticles.Add(newsArticle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(newsArticle);
        }

        // GET: NewsArticles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsArticle newsArticle = db.NewsArticles.Find(id);
            if (newsArticle == null)
            {
                return HttpNotFound();
            }
            return View(newsArticle);
        }

        // POST: NewsArticles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NewsArticleId,Author,Title,Article,ImageUrl,OriginalUrl,PublishDate")] NewsArticle newsArticle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(newsArticle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newsArticle);
        }

        // GET: NewsArticles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsArticle newsArticle = db.NewsArticles.Find(id);
            if (newsArticle == null)
            {
                return HttpNotFound();
            }
            return View(newsArticle);
        }

        // POST: NewsArticles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NewsArticle newsArticle = db.NewsArticles.Find(id);
            db.NewsArticles.Remove(newsArticle);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
