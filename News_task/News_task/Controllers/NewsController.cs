using News_task.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace News_task.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        [HttpGet]
        public ActionResult NewsList()
        {
            NewsDBEntities1 db = new NewsDBEntities1();
            var data = db.News.ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View(new News());
        }
        [HttpPost]
        public ActionResult Create(News nn)
        {
            if (ModelState.IsValid)
            {
                NewsDBEntities1 db = new NewsDBEntities1();
                db.News.Add(nn);
                db.SaveChanges();
                return RedirectToAction("NewsList");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            NewsDBEntities1 db=new NewsDBEntities1();
            var news = (from n in db.News where n.Id == id select n).FirstOrDefault();
            return View(news);
        }

        [HttpPost]
        public ActionResult Edit(News nn)
        {
            if (ModelState.IsValid)
            {
                NewsDBEntities1 db = new NewsDBEntities1();
                var news=(from n in db.News where n.Id == nn.Id select n).FirstOrDefault();
                db.Entry(news).CurrentValues.SetValues(nn);
                db.SaveChanges();
                return RedirectToAction("NewsList");
            }
            return View();
        }
    }
}