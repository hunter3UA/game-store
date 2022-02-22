using GameStore.DAL.Repositories;
using GameStore.DAL.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.DAL.UoW
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly StoreDbContext _dbContext;

        public UnitOfWork(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        private ICommentRepository _commentRepository;
        private IPlatformRepository _platformRepository;
        private IGenreRepository _genreRepository;
        private IGameRepository _gameRepository;


        public ICommentRepository CommentRepository
        {
            get
            {
                if (_commentRepository == null)
                    _commentRepository = new CommentRepository(_dbContext);
                return _commentRepository;
            }
        }

        public IPlatformRepository PlatformRepository
        {
            get
            {
                if (_platformRepository == null)
                    _platformRepository = new PlatformRepository(_dbContext);
                return _platformRepository;

            }
        }

        public IGenreRepository GenreRepository
        {
            get
            {
                if (_genreRepository == null)
                    _genreRepository = new GenreRepository(_dbContext);
                return _genreRepository;
            }
        }

        public IGameRepository GameRepository
        {
            get
            {
                if (_gameRepository == null)
                    _gameRepository = new GameRepository(_dbContext);
                return _gameRepository;
            }
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
