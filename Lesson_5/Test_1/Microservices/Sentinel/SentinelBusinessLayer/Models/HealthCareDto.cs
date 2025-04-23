using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SentinelBusinessLayer.Models
{
    public class HealthCareDto
    {
        public string TreatmentName { get; set; }

        public DateTime InjectedAt { get; set; }

        public DateTime ExpirationDate { get; set; }

        public Guid PetId { get; set; }

        public Guid VendorId { get; set; }

        public Guid StoreId { get; set; }
    }
}
