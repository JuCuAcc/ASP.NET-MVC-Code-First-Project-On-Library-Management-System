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
    public class BookIssueLogsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BookIssueLogs
        public ActionResult Index()
        {
            var bookIssueLogs = db.BookIssueLog.Include(b => b.BookIssue).Include(b => b.Members);
            return View(bookIssueLogs.ToList());
        }

        // GET: BookIssueLogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookIssueLog bookIssueLog = db.BookIssueLog.Find(id);
            if (bookIssueLog == null)
            {
                return HttpNotFound();
            }
            return View(bookIssueLog);
        }

        // GET: BookIssueLogs/Create
        public ActionResult Create()
        {
            ViewBag.IssueID = new SelectList(db.BookIssues, "IssueID", "IssueID");
            ViewBag.MemberID = new SelectList(db.Members, "MemberID", "MemberName");
            return View();
        }

        // POST: BookIssueLogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,IssuedTime,ReturnTime,MemberID,IssueID")] BookIssueLog bookIssueLog)
        {
            if (ModelState.IsValid)
            {
                db.BookIssueLog.Add(bookIssueLog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IssueID = new SelectList(db.BookIssues, "IssueID", "IssueID", bookIssueLog.IssueID);
            ViewBag.MemberID = new SelectList(db.Members, "MemberID", "MemberName", bookIssueLog.MemberID);
            return View(bookIssueLog);
        }

        // GET: BookIssueLogs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookIssueLog bookIssueLog = db.BookIssueLog.Find(id);
            if (bookIssueLog == null)
            {
                return HttpNotFound();
            }
            ViewBag.IssueID = new SelectList(db.BookIssues, "IssueID", "IssueID", bookIssueLog.IssueID);
            ViewBag.MemberID = new SelectList(db.Members, "MemberID", "MemberName", bookIssueLog.MemberID);
            return View(bookIssueLog);
        }

        // POST: BookIssueLogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,IssuedTime,ReturnTime,MemberID,IssueID")] BookIssueLog bookIssueLog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookIssueLog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IssueID = new SelectList(db.BookIssues, "IssueID", "IssueID", bookIssueLog.IssueID);
            ViewBag.MemberID = new SelectList(db.Members, "MemberID", "MemberName", bookIssueLog.MemberID);
            return View(bookIssueLog);
        }

        // GET: BookIssueLogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookIssueLog bookIssueLog = db.BookIssueLog.Find(id);
            if (bookIssueLog == null)
            {
                return HttpNotFound();
            }
            return View(bookIssueLog);
        }

        // POST: BookIssueLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookIssueLog bookIssueLog = db.BookIssueLog.Find(id);
            db.BookIssueLog.Remove(bookIssueLog);
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
