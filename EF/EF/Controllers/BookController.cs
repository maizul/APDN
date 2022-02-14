using EF.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EF.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            BookDBEntities1 db = new BookDBEntities1();
            var data = db.books.ToList();
            return View(data);
        }
    }
}