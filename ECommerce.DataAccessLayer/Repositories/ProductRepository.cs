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
    public class ProductRepository : GenericRepository<Product>, IProductDal
    {
        public ProductRepository(ECommerceContext context) : base(context)
        {
        }
    }
}
