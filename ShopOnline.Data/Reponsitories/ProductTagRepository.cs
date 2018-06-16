using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopOnline.Data.Inframestructure;
using ShopOnline.Model.Models;

namespace ShopOnline.Data.Reponsitories
{
    public interface IProductTagRepository: IRepository<ProductTag>
    {

    }
   public class ProductTagRepository:RepositoryBase<ProductTag>,IProductTagRepository
    {
        public ProductTagRepository(IDbFactory dbFactory):base(dbFactory)
        {

        }
    }
}
