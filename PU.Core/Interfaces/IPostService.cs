using PU.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PU.Core.Interfaces
{
    public interface IPostService: IRepository<Post>
    {
        Task<IEnumerable<Post>> GetPostByUser(int idUser);
    }
}
