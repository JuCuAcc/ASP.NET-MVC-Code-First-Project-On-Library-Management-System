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
    public class BookIssuesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BookIssues
        public ActionResult Index()
        {
            return View(db.BookIssues.ToList());
        }

        // GET: BookIssues/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookIssue bookIssue = db.BookIssues.Find(id);
            if (bookIssue == null)
            {
                return HttpNotFound();
            }
            return View(bookIssue);
        }

        // GET: BookIssues/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookIssues/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IssueID,IssuedTime")] BookIssue bookIssue)
        {
            if (ModelState.IsValid)
            {
                db.BookIssues.Add(bookIssue);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bookIssue);
        }

        // GET: BookIssues/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookIssue bookIssue = db.BookIssues.Find(id);
            if (bookIssue == null)
            {
                return HttpNotFound();
            }
            return View(bookIssue);
        }

        // POST: BookIssues/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IssueID,IssuedTime")] BookIssue bookIssue)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookIssue).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookIssue);
        }

        // GET: BookIssues/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookIssue bookIssue = db.BookIssues.Find(id);
            if (bookIssue == null)
            {
                return HttpNotFound();
            }
            return View(bookIssue);
        }

        // POST: BookIssues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookIssue bookIssue = db.BookIssues.Find(id);
            db.BookIssues.Remove(bookIssue);
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
