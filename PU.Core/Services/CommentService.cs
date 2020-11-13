using PU.Core.Entities;
using PU.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PU.Core.Services
{
    public class CommentService : ICommentRepository
    {

        private readonly IUnitOfWork _unitOfWork;
        public CommentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Comment> GetAll()
        {
            return _unitOfWork.CommentRepository.GetAll();
        }

        public async Task<Comment> GetById(int id)
        {
            return await _unitOfWork.CommentRepository.GetById(id);
        }

        public async Task Add(Comment comment)
        {
            await _unitOfWork.CommentRepository.Add(comment);
            await _unitOfWork.SaveChangesAsync();
            
        }

        public void Update(Comment comment)
        {
            _unitOfWork.CommentRepository.Update(comment);
            _unitOfWork.SaveChanges();
        }

        public async Task Delete(int id)
        {
            await _unitOfWork.CommentRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
