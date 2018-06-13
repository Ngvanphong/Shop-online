﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DamvayShop.Web.Models
{
    public class ProductTagViewModel
    {

        public int ProductID { get; set; }


        public virtual ProductViewModel Product { get; set; }


        public string TagID { get; set; }

 
        public virtual TagViewModel Tag { get; set; }
      
    }
}