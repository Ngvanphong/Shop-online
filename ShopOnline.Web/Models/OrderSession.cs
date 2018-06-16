using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Web.Models
{
    public class OrderSession
    {
        public decimal totalPrice;
        public decimal taxTransferPrice;
        public OrderViewModel orderVm;
    }
}