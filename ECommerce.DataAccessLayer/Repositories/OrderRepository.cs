using ECommerce.DataAccessLayer.Abstract;
using ECommerce.DataAccessLayer.Context;
using ECommerce.EntityLayer.Conrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccessLayer.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderDal
    {
        private readonly ECommerceContext _context;

        public OrderRepository(ECommerceContext context) : base(context)
        {
            _context = context;
        }
    }
}
