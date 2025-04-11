using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string SecondName { get; set; }
        public List<ProjectModel>? Projects { get; set; }
        public VoteModel? Vote { get; set; }
        public List<CommentModel>? Comments { get; set; }
    }
}
