using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Models
{
    public class ProjectModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreationDate { get; set; }
        public UserModel User { get; set; }
        public List<CategoryModel>? Categories { get; set; }
        public VoteModel? Vote { get; set; }
        public List<CommentModel>? Comments { get; set; }
    }
}
