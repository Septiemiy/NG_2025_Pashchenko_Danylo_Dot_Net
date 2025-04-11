using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string SecondName { get; set; }
        public virtual List<Project>? Projects { get; set; }
        public virtual Vote? Vote { get; set; }
        public virtual List<Comment>? Comments { get; set; }
    }
}
