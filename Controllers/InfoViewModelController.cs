using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Code_First_Jashim.Models;
using Code_First_Jashim.ViewModel;

namespace Code_First_Jashim.Controllers
{
    public class InfoViewModelController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: InfoViewModel
        public ActionResult Index()
        {
            return View(db.InfoViewModels.ToList());
        }

        // GET: InfoViewModel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InfoViewModel infoViewModel = db.InfoViewModels.Find(id);
            if (infoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(infoViewModel);
        }

        // GET: InfoViewModel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InfoViewModel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LiberianID,LiberianName,Age,Email,Address")] InfoViewModel infoViewModel)
        {
            if (ModelState.IsValid)
            {
                db.InfoViewModels.Add(infoViewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(infoViewModel);
        }

        // GET: InfoViewModel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InfoViewModel infoViewModel = db.InfoViewModels.Find(id);
            if (infoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(infoViewModel);
        }

        // POST: InfoViewModel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LiberianID,LiberianName,Age,Email,Address")] InfoViewModel infoViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(infoViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(infoViewModel);
        }

        // GET: InfoViewModel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InfoViewModel infoViewModel = db.InfoViewModels.Find(id);
            if (infoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(infoViewModel);
        }

        // POST: InfoViewModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InfoViewModel infoViewModel = db.InfoViewModels.Find(id);
            db.InfoViewModels.Remove(infoViewModel);
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
