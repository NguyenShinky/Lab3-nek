using lab3.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab3.Controllers
{
    public class BookController : Controller
    {

        public ActionResult ListBook()
        {
            BookManagerContext context = new BookManagerContext();
            var listBook = context.Book.ToList();
            return View(listBook);
        }

        [Authorize]

        public ActionResult Buy(int id)
        {
            BookManagerContext context = new BookManagerContext();
            Book book = context.Book.SingleOrDefault(p => p.ID == id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        [Authorize]

        public ActionResult Create()
        {

            return View();

        }

        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book)
        {
            BookManagerContext context = new BookManagerContext();
            var search = context.Book.SingleOrDefault(p => p.ID == book.ID);
            if (search != null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Book.AddOrUpdate(book);
                context.SaveChanges();
                return RedirectToAction("ListBook");
            }
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            BookManagerContext context = new BookManagerContext();
            Book book = context.Book.SingleOrDefault(p => p.ID == id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        [Authorize]
        [HttpPost]

        public ActionResult Edit(Book book)
        {

            BookManagerContext context = new BookManagerContext();
            Book bookUpdate = context.Book.SingleOrDefault(p => p.ID == book.ID);
            if (bookUpdate != null)
            {
                context.Book.AddOrUpdate(book);
                context.SaveChanges();
            }

            return RedirectToAction("LitsBook");

        }



        public ActionResult Delete(int Id)
        {
            using (BookManagerContext context = new BookManagerContext())
            {
                return View(context.Book.Where(p => p.ID == Id).FirstOrDefault());
            }
        }

        [HttpPost]
        [Authorize]
        public ActionResult Delete(int Id, FormCollection collection)
        {
            try
            {
                using (BookManagerContext context = new BookManagerContext())
                {
                    Book book = context.Book.Where(p => p.ID == Id).FirstOrDefault();
                    context.Book.Remove(book);
                    context.SaveChanges();
                }
                return RedirectToAction("ListBook");
            }
            catch
            {
                return View();
            }
        }



        // GET: Book
        public ActionResult Index()
        {
            return View();
        }
    }
}