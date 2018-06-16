using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineShop.Model.Models;

namespace OnlineShop.Web.Models
{
    public class OrderDetailViewModel
    {

        public int OrderID { set; get; }

        public int ProductID { set; get; }

        public int Quantity { set; get; }

        public decimal Price { set; get; }

        public int SizeId { get; set; }


        public virtual ProductViewModel Product { set; get; }
     
       
    }
}