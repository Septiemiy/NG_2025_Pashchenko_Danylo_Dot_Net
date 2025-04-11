using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Project : BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreationDate { get; set; }
        public Guid CreatorId { get; set; } 
        public Guid CategoryId { get; set; }
        public virtual User User { get; set; }
        public virtual List<Category>? Categories { get; set; }
        public virtual Vote? Vote { get; set; }
        public virtual List<Comment>? Comments { get; set; }
    }
}
