using DAL_Core.Entities;
using DAL_Core.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendorDAL.Repositories.Interfaces
{
    public interface IVendorRepository : IRepository<Vendor>
    {
        Task<Vendor?> GetVendorWithHealthCareRecords(Guid vendorId);
        Task<ICollection<Vendor>?> GetVendorsByContractType(ContractType contractType);
    }
}
