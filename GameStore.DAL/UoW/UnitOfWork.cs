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

        public UnitOfWork(
            StoreDbContext dbContext,
            ICommentRepository commentRepository,
            IPlatformRepository platformRepository,
            IGenreRepository genreRepository,
            IGameRepository gameRepository
            )
        {
            _dbContext = dbContext;
            CommentRepository = commentRepository;
            PlatformRepository = platformRepository;
            GenreRepository = genreRepository;
            GameRepository = gameRepository;
        }
        


        public ICommentRepository CommentRepository { get; }

        public IPlatformRepository PlatformRepository { get; }

        public IGenreRepository GenreRepository { get; }

        public IGameRepository GameRepository { get; }
        

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
