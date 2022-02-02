using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

using Code_First_Jashim.Models;
using PagedList;
using PagedList.Mvc;
using System.IO;


namespace Code_First_Jashim.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index(int page = 1, int pageSize = 2)
        {
            //var books = db.Books.Include(b => b.BookCategories);
            //return View(books.ToList());

            List<Books> books = db.Books.ToList();
            PagedList<Books> model = new PagedList<Books>(books, page, pageSize);
            return View(model);
        }

        // Details
        public ActionResult Details(int id = 0)
        {

            Books book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }

            return View(book);
        }

        IEnumerable<Books> GetAllBook()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                return db.Books.ToList<Books>();
            }
        }

        //Create
        public ActionResult Create()
        {
            Books book = new Books();
            ViewBag.CategoryID = new SelectList(db.BookCategories, "CategoryID", "Category");
            return View(book);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(Books book)
        {
            try
            {
                if (ModelState.IsValid && book.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(book.ImageUpload.FileName);
                    string extension = Path.GetExtension(book.ImageUpload.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    book.ImagePath = "~/Images/" + fileName;
                    book.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Images/"), fileName));

                    db.Books.Add(book);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                else if (ModelState.IsValid && book.ImageUpload == null)
                {
                    db.Books.Add(book);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.CategoryID = new SelectList(db.BookCategories, "CategoryID", "Category", book.CategoryID);
                return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "Details", GetAllBook()), message = "The Record Submitted Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }


        }


        // Edit 
        public ActionResult Edit(int id = 0)
        {

            Books book = db.Books.Find(id);

            if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.BookCategories, "CategoryID", "Category", book.CategoryID);
            return View(book);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(Books book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified; //using System.Data.Entity;
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            return View(book);
        }


        public ActionResult Delete(int id = 0)
        {
            Books book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }

            return View(book);
        }



        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public ActionResult DeleteConfirmed(int id)
        {
            Books book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        //Extra

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