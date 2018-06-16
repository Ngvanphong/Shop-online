using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopOnline.Data.Inframestructure;
using ShopOnline.Model.Models;

namespace ShopOnline.Data.Reponsitories
{
    public interface ISystemConfigRepository : IRepository<SystemConfig>
    {

    }
   public class SystemConfigRepository:RepositoryBase<SystemConfig>,ISystemConfigRepository
    {
        public SystemConfigRepository(IDbFactory dbFactory):base(dbFactory)
        {

        }
    }
}
