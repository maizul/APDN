using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Product_Loop.Models
{
    public class Product
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        
    }
}