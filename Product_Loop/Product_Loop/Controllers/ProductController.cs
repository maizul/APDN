using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Product_Loop.Models;
using System.Data.SqlClient;

namespace Product_Loop.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Home()
        {
            Product p = new Product();
            p.Name = "Techno";
            p.Id = 12;
            p.Price = 3400; 
            return View(p);
        }

        public ActionResult List()
        {
            List<Product> products = new List<Product>();
            for(int i = 0; i < 100; i++)
            {
                var p = new Product
                {
                    Id = i + 1,
                    Name = "Samsung " + (i + 1),
                    Price = i + 200
                };
                products.Add(p);
            }
            return View(products);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new Product());
        }

        [HttpPost]
        public ActionResult Create( Product s)
        {
            List<Product> products = new List<Product>();
            if (ModelState.IsValid)
            {
                string connString = @"Data Source=SAGOR\SQLEXPRESS01;Initial Catalog=product;Integrated Security=True";
                SqlConnection con=new SqlConnection(connString);
                con.Open();
                string query = "INSERT INTO products2 (Id, Name, Price) VALUES (@Id, @Name, @Price)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();

                //products.Add(s);
                con.Close();


                //return RedirectToAction("List");
            }
            return View(s);
        }
        [HttpPost]
        public ActionResult Submit( Product s)
        {
            return View(s);
        }

    }
}