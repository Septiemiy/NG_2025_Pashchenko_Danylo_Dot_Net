using AutoMapper;
using BusinessLogicLayer.Models;
using BusinessLogicLayer.Services.Interface;
using DataAccessLayer.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryModel?> GetCategoryAsync(Guid id)
        {
            var category = await _categoryRepository.GetAsync(id);
            return _mapper.Map<CategoryModel>(category);
        }
        public async Task<ICollection<CategoryModel>?> GetAllCategoriesAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return _mapper.Map<ICollection<CategoryModel>>(categories);
        }

        public async Task<ICollection<CategoryModel>?> GetAllCategoriesWithProjectsAsync()
        {
            var categories = await _categoryRepository.GetAllCategoriesWithProjectsAsync();
            return _mapper.Map<ICollection<CategoryModel>>(categories);
        }

        public async Task<CategoryModel?> GetCategoryWithProjectsAsync(Guid id)
        {
            var category = await _categoryRepository.GetCategoryWithProjectsAsync(id);
            return _mapper.Map<CategoryModel>(category);
        }
    }
}
