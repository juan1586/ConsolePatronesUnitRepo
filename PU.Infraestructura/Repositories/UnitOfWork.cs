using PU.Core.Entities;
using PU.Core.Interfaces;
using PU.Infraestructura.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PU.Infraestructura.Repositories
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Comment> _commentRepository;
        private readonly IPostService _postRepository;
        private readonly PUContext _context;

        public UnitOfWork(PUContext context)
        {
            _context = context;
        }

        public IRepository<User> UserRepository => _userRepository ?? new BaseRepository<User>(_context);
        public IRepository<Comment> CommentRepository => _commentRepository ?? new BaseRepository<Comment>(_context);
        public IPostService PostRepository => _postRepository ?? new PostRepository(_context);

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
