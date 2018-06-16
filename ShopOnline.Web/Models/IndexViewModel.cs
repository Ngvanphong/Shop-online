using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopOnline.Web.Models
{
    public class IndexViewModel
    {
       public IEnumerable<SlideViewModel> slideVm;
        public IEnumerable<ProductViewModel> productHotVm;
        public IEnumerable<ProductViewModel> productUpdateLastedVm;
        public IEnumerable<PostViewModel> postVm;
        public  string MetaKeyword;
        public  string Title;
        public  string MetaDiscription;
    }
}