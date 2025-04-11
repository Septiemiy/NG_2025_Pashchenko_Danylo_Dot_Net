using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Category : BaseEntity
    {
        public string? Description { get; set; }
        public virtual List<Project>? Projects { get; set; }
    }
}
