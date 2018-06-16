using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopOnline.Data.Inframestructure;
using ShopOnline.Model.Models;

namespace ShopOnline.Data.Reponsitories
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
