using BusinessLogicLayer.Models;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Interface
{
    public interface ICategoryService
    {
        Task<CategoryModel?> GetCategoryAsync(Guid id);
        Task<ICollection<CategoryModel>?> GetAllCategoriesAsync();
        Task<CategoryModel?> GetCategoryWithProjectsAsync(Guid id);
        Task<ICollection<CategoryModel>?> GetAllCategoriesWithProjectsAsync();
    }
}
