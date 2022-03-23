using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment.Models.DB;

namespace Assignment.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        [HttpGet]
        public ActionResult DepartmentList()
        {
            AssignmentEntities db = new AssignmentEntities();
            var data = db.Departments.ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View(new Department());
        }
        [HttpPost]
        public ActionResult Create(Department n)
        {
            if (ModelState.IsValid)
            {
                AssignmentEntities db = new AssignmentEntities();
                db.Departments.Add(n);
                db.SaveChanges();
                return RedirectToAction("DepartmentList");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            AssignmentEntities db = new AssignmentEntities();
            var data = (from n in db.Departments where n.Id == id select n).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Department nn)
        {
            if (ModelState.IsValid)
            {
                AssignmentEntities db = new AssignmentEntities();
                var data = (from n in db.Departments where n.Id == nn.Id select n).FirstOrDefault();
                db.Entry(data).CurrentValues.SetValues(nn);
                db.SaveChanges();
                return RedirectToAction("DepartmentList");
            }
            return View();
        }
    }
}