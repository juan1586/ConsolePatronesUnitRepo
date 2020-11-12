using Microsoft.EntityFrameworkCore;
using PU.Core.Entities;
using PU.Core.Interfaces;
using PU.Infraestructura.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PU.Infraestructura.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        // Declaración de variables
        private readonly PUContext _puContext;
        protected DbSet<T> _entities;

        public BaseRepository(PUContext puContext)
        {
            _puContext = puContext;
            _entities = puContext.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable();
        }

        public async Task<T> GetById(int id)
        {
            return await _entities.FindAsync(id);
        }
        public async Task Add(T entity)
        {
            await _entities.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _entities.Update(entity);
        }

        public async Task Delete(int id)
        {
            T entity = await GetById(id);
            _entities.Remove(entity);
        }
    }
}
