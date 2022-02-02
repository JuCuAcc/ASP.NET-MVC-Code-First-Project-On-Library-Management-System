using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Code_First_Jashim.Models;

namespace Code_First_Jashim.Controllers
{
    [Authorize]
    public class BookCategoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BookCategories
        public ActionResult Index()
        {
            return View(db.BookCategories.ToList());
        }

        // GET: BookCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookCategories bookCategories = db.BookCategories.Find(id);
            if (bookCategories == null)
            {
                return HttpNotFound();
            }
            return View(bookCategories);
        }

        // GET: BookCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryID,Category")] BookCategories bookCategories)
        {
            if (ModelState.IsValid)
            {
                db.BookCategories.Add(bookCategories);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bookCategories);
        }

        // GET: BookCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookCategories bookCategories = db.BookCategories.Find(id);
            if (bookCategories == null)
            {
                return HttpNotFound();
            }
            return View(bookCategories);
        }

        // POST: BookCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryID,Category")] BookCategories bookCategories)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookCategories).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookCategories);
        }

        // GET: BookCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookCategories bookCategories = db.BookCategories.Find(id);
            if (bookCategories == null)
            {
                return HttpNotFound();
            }
            return View(bookCategories);
        }

        // POST: BookCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookCategories bookCategories = db.BookCategories.Find(id);
            db.BookCategories.Remove(bookCategories);
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
