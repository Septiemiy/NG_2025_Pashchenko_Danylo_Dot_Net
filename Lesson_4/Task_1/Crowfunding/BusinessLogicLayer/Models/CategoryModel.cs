using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Models
{
    public class CategoryModel
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public List<ProjectModel>? Projects { get; set; }
    }
}
