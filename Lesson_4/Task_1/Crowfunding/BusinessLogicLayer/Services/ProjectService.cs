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
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;

        public ProjectService(IProjectRepository projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        public async Task<ProjectModel?> GetProjectAsync(Guid id)
        {
            var project = await _projectRepository.GetAsync(id);
            return _mapper.Map<ProjectModel>(project);
        }

        public async Task<ICollection<ProjectModel>?> GetAllProjectsAsync()
        {
            var projects = await _projectRepository.GetAllAsync();
            return _mapper.Map<ICollection<ProjectModel>>(projects);
        }

        public async Task<ICollection<ProjectModel>?> GetAllProjectsWithUsersAsync()
        {
            var projects = await _projectRepository.GetAllProjectsWithUsersAsync();
            return _mapper.Map<ICollection<ProjectModel>>(projects);
        }

        public async Task<ProjectModel?> GetProjectWithCategoriesAsync(Guid id)
        {
            var project = await _projectRepository.GetProjectWithCategoriesAsync(id);
            return _mapper.Map<ProjectModel>(project);
        }

        public async Task<ProjectModel?> GetProjectWithCommentaryAsync(Guid id)
        {
            var project = await _projectRepository.GetProjectWithCommentaryAsync(id);
            return _mapper.Map<ProjectModel>(project);
        }

        public async Task<ProjectModel?> GetProjectWithUserAsync(Guid id)
        {
            var project = await _projectRepository.GetProjectWithUserAsync(id);
            return _mapper.Map<ProjectModel>(project);
        }

        public async Task<ProjectModel?> GetProjectWithVoteAsync(Guid id)
        {
            var project = await _projectRepository.GetProjectWithVoteAsync(id);
            return _mapper.Map<ProjectModel>(project);
        }
    }
}
