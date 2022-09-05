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
    public class CustomerReadRepository : ReadRepository<Customer>, ICustomerReadRepository
    {
        public CustomerReadRepository(EShopAPIDbContext context) : base(context)
        {
        }
    }
}
