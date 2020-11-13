using PU.Core.Entities;
using PU.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PU.Core.Services
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PostService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Add(Post entity)
        {
            await _unitOfWork.PostRepository.Add(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            await _unitOfWork.PostRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public IEnumerable<Post> GetAll()
        {
            return _unitOfWork.PostRepository.GetAll();
        }

        public async Task<Post> GetById(int id)
        {
            return await _unitOfWork.PostRepository.GetById(id);
        }

        public async Task<IEnumerable<Post>> GetPostByUser(int idUser)
        {
            return await _unitOfWork.PostRepository.GetPostByUser(idUser);
        }

        public void Update(Post entity)
        {
            _unitOfWork.PostRepository.Update(entity);
        }
    }
}
