using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_EF6_Example.Models
{
    public class ProductModel
    {
        public int productid { get; set; }
        public string productname { get; set; }
        public int productprice { get; set; }
        public DateTime productAddedDate { get; set; }
    }
}