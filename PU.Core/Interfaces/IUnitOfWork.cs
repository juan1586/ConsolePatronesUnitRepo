using PU.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PU.Core.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IRepository<User> UserRepository { get; }

        void SaveChanges();

        Task SaveChangesAsync();
    }
}
