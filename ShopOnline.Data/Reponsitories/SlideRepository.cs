using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Data.Inframestructure;
using OnlineShop.Model.Models;

namespace OnlineShop.Data.Reponsitories
{
    public interface ISlideRepository: IRepository<Slide>
    {

    }
   public class SlideRepository:RepositoryBase<Slide>,ISlideRepository
    {
        public SlideRepository(IDbFactory dbFactory):base(dbFactory)
        {

        }
    }
}
