using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Data.Inframestructure;
using OnlineShop.Model.Models;

namespace OnlineShop.Data.Reponsitories
{
    public interface ISupportOnlineRepository: IRepository<SupportOnline>
    {

    }
   public class SupportOnlineRepository:RepositoryBase<SupportOnline>,ISupportOnlineRepository
    {
        public SupportOnlineRepository(IDbFactory dbFactory):base(dbFactory)
        {

        }
    }
}
