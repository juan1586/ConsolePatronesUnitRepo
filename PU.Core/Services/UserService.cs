using PU.Core.Entities;
using PU.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PU.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<User> GetAll()
        {
            return _unitOfWork.UserRepository.GetAll();
        }

        public async Task<User> GetById(int id)
        {
            return await _unitOfWork.UserRepository.GetById(id);
        }

        public async Task<bool> Add(User user)
        {
             await _unitOfWork.UserRepository.Add(user);
             await _unitOfWork.SaveChangesAsync();
             return true;
        }

        public void Update(User user)
        {
            _unitOfWork.UserRepository.Update(user);
            _unitOfWork.SaveChanges();
        }

        public async Task<bool> Delete(int id)
        {
            await _unitOfWork.UserRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
        
    }
}
