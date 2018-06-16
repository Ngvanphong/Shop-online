﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopOnline.Data.Inframestructure;

namespace ShopOnline.Data.Reponsitories
{

    public interface IUserRoleRepository : IRepository<IdentityUserRole>
    {

    }
    public class UserRoleRepository : RepositoryBase<IdentityUserRole>, IUserRoleRepository
    {
        public UserRoleRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}