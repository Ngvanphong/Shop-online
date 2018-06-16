using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopOnline.Data.Inframestructure;
using ShopOnline.Model.Models;

namespace ShopOnline.Data.Reponsitories
{
    public interface IPageRepository: IRepository<Page>
    {

    }
    public class PageRepository:RepositoryBase<Page>,IPageRepository
    {
        public PageRepository(IDbFactory dbFactory): base(dbFactory)
        {

        }
    }
}
