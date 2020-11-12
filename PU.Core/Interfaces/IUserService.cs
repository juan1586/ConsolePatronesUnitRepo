using PU.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PU.Core.Interfaces
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();
    }
}
