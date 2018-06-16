using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Data.Inframestructure;
using OnlineShop.Model.Models;

namespace OnlineShop.Data.Reponsitories
{
    public interface IPostTagRepository: IRepository<PostTag>
    {

    }
    public class PostTagRepository:RepositoryBase<PostTag>,IPostTagRepository
    {
        public PostTagRepository(IDbFactory dbFactory):base(dbFactory)
        {

        }
    }
}
