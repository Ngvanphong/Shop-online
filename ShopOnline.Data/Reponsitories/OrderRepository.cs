using ShopOnline.Data.Inframestructure;
using ShopOnline.Model.Models;

namespace ShopOnline.Data.Reponsitories
{
    public interface IOrderRepository : IRepository<Order>
    {
       
    }

    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}