﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Inframestructure
{
    public interface IUnitOfWork
    {
        void Commit();
        
    }
}
