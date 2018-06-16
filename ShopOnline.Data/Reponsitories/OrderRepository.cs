using OnlineShop.Data.Inframestructure;
using OnlineShop.Model.Models;

namespace OnlineShop.Data.Reponsitories
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