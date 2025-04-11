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
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        public CommentService(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<CommentModel?> GetCommentAsync(Guid id)
        {
            var comment = await _commentRepository.GetAsync(id);
            return _mapper.Map<CommentModel>(comment);
        }

        public async Task<ICollection<CommentModel>?> GetAllCommentsAsync()
        {
            var comments = await _commentRepository.GetAllAsync();
            return _mapper.Map<ICollection<CommentModel>>(comments);
        }

        public async Task<ICollection<CommentModel>?> GetAllCommentsWithProjectsAsync()
        {
            var comments = await _commentRepository.GetAllCommentsWithProjectsAsync();
            return _mapper.Map<ICollection<CommentModel>>(comments);
        }

        public async Task<ICollection<CommentModel>?> GetAllCommentsWithUsersAsync()
        {
            var comments = await _commentRepository.GetAllCommentsWithUsersAsync();
            return _mapper.Map<ICollection<CommentModel>>(comments);
        }

        public async Task<ICollection<CommentModel>?> GetCommentsByProjectIdAsync(Guid projectId)
        {
            var comments = await _commentRepository.GetCommentsByProjectId(projectId);
            return _mapper.Map<ICollection<CommentModel>>(comments);
        }

        public async Task<ICollection<CommentModel>?> GetCommentsByUserIdAsync(Guid userId)
        {
            var comments = await _commentRepository.GetCommentsByUserId(userId);
            return _mapper.Map<ICollection<CommentModel>>(comments);
        }
    }
}
