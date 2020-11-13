using Microsoft.EntityFrameworkCore;
using PU.Core.Entities;
using PU.Core.Interfaces;
using PU.Infraestructura.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PU.Infraestructura.Repositories
{
    class PostRepository : BaseRepository<Post>, IPostService
    {
        public PostRepository(PUContext puContext): base(puContext) { }
        public async Task<IEnumerable<Post>> GetPostByUser(int idUser)
        {
            return await _entities.Where(x => x.UserId == idUser).ToListAsync();
        }
    }
}
