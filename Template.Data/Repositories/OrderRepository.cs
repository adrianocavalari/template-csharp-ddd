using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using Template.Data.Interfaces;
using Template.Domain.Entities;
using Template.Domain.Interfaces.Repository;

namespace Template.Data.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(DbContext context) 
            : base(context)
        {
        }
    }
}
