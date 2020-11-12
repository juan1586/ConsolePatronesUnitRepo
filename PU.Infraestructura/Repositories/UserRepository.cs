using Microsoft.EntityFrameworkCore;
using PU.Core.Entities;
using PU.Core.Interfaces;
using PU.Infraestructura.Data;
using PU.Infraestructura.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PU.Core.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(PUContext puContext):base(puContext)
        {

        }

        public async Task<User> GetUser(int id)
        {
            return await _entities.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
