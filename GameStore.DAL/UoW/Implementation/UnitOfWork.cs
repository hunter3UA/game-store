using GameStore.DAL.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GameStore.DAL.Repositories.Abstract;
using GameStore.DAL.Repositories.Implementation;

namespace GameStore.DAL.UoW.Abstract
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreDbContext _dbContext;
        private ICommentRepository _commentRepository;
        private IGameRepository _gameRepository;
        private IGenreRepository _genreRepository;
        private IPlatformTypeRepository _platformTypeRepository;

        public UnitOfWork(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ICommentRepository CommentRepository
        {
            get
            {
                if (_commentRepository == null)
                    _commentRepository = new CommentRepository(_dbContext);
                return _commentRepository;

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
        public IGenreRepository GenreRepository
        {
            get
            {
                if (_genreRepository == null)
                    _genreRepository = new GenreRepository(_dbContext);
                return _genreRepository;
            }
        }
        public IPlatformTypeRepository PlatformTypeRepository
        {
            get
            {
                if (_platformTypeRepository == null)
                    _platformTypeRepository = new PlatformTypeRepository(_dbContext);
                return _platformTypeRepository;
            }
        }

 

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
