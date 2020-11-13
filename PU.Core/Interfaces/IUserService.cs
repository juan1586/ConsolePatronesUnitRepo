using PU.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PU.Core.Interfaces
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();
        Task<User> GetById(int id);
        Task<bool> Add(User user);
        void Update(User user);
        Task<bool> Delete(int id);
    }
}
