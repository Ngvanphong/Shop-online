using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopOnline.Data.Inframestructure;
using ShopOnline.Model.Models;

namespace ShopOnline.Data.Reponsitories
{
    public interface IProductImageRepository : IRepository<ProductImage>
    {
       
    }
   public class ProductImageRepository:RepositoryBase<ProductImage>,IProductImageRepository
    {
        public ProductImageRepository(IDbFactory dbFactory):base(dbFactory)
        {

        }
    }
}
