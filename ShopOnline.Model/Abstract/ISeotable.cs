﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Model.Abstract
{
    interface ISeotable
    {
        string MetaKeyword { set; get; }
        string MetaDiscription { set; get; }

    }
}
