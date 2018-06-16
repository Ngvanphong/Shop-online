using ShopOnline.Data.Inframestructure;
using ShopOnline.Model.Models;

namespace ShopOnline.Data.Reponsitories
{
    public interface IErrorRepository : IRepository<Error>
    {
    }

    public class ErrorRepository : RepositoryBase<Error>, IErrorRepository
    {
        public ErrorRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}