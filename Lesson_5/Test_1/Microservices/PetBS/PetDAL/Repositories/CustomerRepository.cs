using DAL_Core;
using DAL_Core.Entities;
using PetDAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetDAL.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(PetStoreDbContext ctx) : base(ctx)
        {
        }
    }
}
