using PU.Core.Entities;
using PU.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
