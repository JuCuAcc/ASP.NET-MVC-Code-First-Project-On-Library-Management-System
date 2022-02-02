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
    public class ReservedBooksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ReservedBooks
        public ActionResult Index()
        {
            var reservedBooks = db.ReservedBooks.Include(r => r.BookCategories);
            return View(reservedBooks.ToList());
        }

        // GET: ReservedBooks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReservedBook reservedBook = db.ReservedBooks.Find(id);
            if (reservedBook == null)
            {
                return HttpNotFound();
            }
            return View(reservedBook);
        }

        // GET: ReservedBooks/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.BookCategories, "CategoryID", "Category");
            return View();
        }

        // POST: ReservedBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,AddedTime,NumberOfBooks,CategoryID")] ReservedBook reservedBook)
        {
            if (ModelState.IsValid)
            {
                db.ReservedBooks.Add(reservedBook);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.BookCategories, "CategoryID", "Category", reservedBook.CategoryID);
            return View(reservedBook);
        }

        // GET: ReservedBooks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReservedBook reservedBook = db.ReservedBooks.Find(id);
            if (reservedBook == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.BookCategories, "CategoryID", "Category", reservedBook.CategoryID);
            return View(reservedBook);
        }

        // POST: ReservedBooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,AddedTime,NumberOfBooks,CategoryID")] ReservedBook reservedBook)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reservedBook).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.BookCategories, "CategoryID", "Category", reservedBook.CategoryID);
            return View(reservedBook);
        }

        // GET: ReservedBooks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReservedBook reservedBook = db.ReservedBooks.Find(id);
            if (reservedBook == null)
            {
                return HttpNotFound();
            }
            return View(reservedBook);
        }

        // POST: ReservedBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReservedBook reservedBook = db.ReservedBooks.Find(id);
            db.ReservedBooks.Remove(reservedBook);
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
