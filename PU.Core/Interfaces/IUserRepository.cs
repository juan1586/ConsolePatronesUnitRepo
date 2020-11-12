using PU.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PU.Core.Interfaces
{
    public interface IUserRepository: IRepository<User>
    {
        /// <summary>
        /// Método asíncrono que devuelve un user por su id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<User> GetUser(int id);
    }
}
