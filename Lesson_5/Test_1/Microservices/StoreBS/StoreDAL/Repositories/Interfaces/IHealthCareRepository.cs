using DAL_Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreDAL.Repositories.Interfaces
{
    public interface IHealthCareRepository : IRepository<HealthCare>
    {
        Task<ICollection<HealthCare>> GetAllByStoreIdAsync(Guid storeId);
    }
}
