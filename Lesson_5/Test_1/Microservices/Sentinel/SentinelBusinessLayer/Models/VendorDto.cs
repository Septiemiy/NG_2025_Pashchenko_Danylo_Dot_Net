using SentinelBusinessLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SentinelBusinessLayer.Models
{
    public class VendorDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime? SignedAt { get; set; }

        public DateTime? ExpirationDate { get; set; }

        public ContractType ContractType { get; set; }
    }
}
