using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Models
{
    public class VoteModel
    {
        public Guid Id { get; set; }
        public UserModel User { get; set; }
        public ProjectModel Project { get; set; }
    }
}
