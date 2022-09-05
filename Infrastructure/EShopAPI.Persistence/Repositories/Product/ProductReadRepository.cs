using EShopAPI.Application.Repositories;
using EShopAPI.Domain.Entities;
using EShopAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopAPI.Persistence.Repositories
{
    public class ProductReadRepository : ReadRepository<Product>, IProductReadRepository
    {
        public ProductReadRepository(EShopAPIDbContext context) : base(context)
        {
        }
    }
}
