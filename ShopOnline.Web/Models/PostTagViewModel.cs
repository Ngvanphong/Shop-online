using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopOnline.Web.Models
{
    public class PostTagViewModel
    {
  
        public string PostID { get; set; }
      
        public virtual PostViewModel Post { get; set; }
       
        public string TagID { get; set; }
     
        public virtual TagViewModel Tag { set; get; }
    }
}