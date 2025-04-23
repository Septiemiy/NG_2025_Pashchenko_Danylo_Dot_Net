using DAL_Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreBL.Models
{
    public class PetDTO
    {
        public string Name { get; set; }
        public string Breed { get; set; }
        public PetTypes Type { get; set; }
        public Guid StoreId { get; set; }
        public Guid? CustomerId { get; set; }
    }
}
