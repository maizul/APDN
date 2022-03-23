using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment.Models.DB;

namespace Assignment.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        [HttpGet]
        public ActionResult StudentList()
        {
            AssignmentEntities db = new AssignmentEntities();
            var data = db.Students.ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View(new Student());
        }
        [HttpPost]
        public ActionResult Create(Student n)
        {
            if (ModelState.IsValid)
            {
                AssignmentEntities db = new AssignmentEntities();
                db.Students.Add(n);
                db.SaveChanges();
                return RedirectToAction("StudentList");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            AssignmentEntities db = new AssignmentEntities();
            var data = (from n in db.Students where n.Id == id select n).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Student nn)
        {
            if (ModelState.IsValid)
            {
                AssignmentEntities db = new AssignmentEntities();
                var data = (from n in db.Students where n.Id == nn.Id select n).FirstOrDefault();
                db.Entry(data).CurrentValues.SetValues(nn);
                db.SaveChanges();
                return RedirectToAction("StudentList");
            }
            return View();
        }
    }
}