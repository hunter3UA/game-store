using System;
using System.Threading.Tasks;
using GameStore.DAL.Repositories.Abstract;
using GameStore.DAL.Context;
using GameStore.DAL.Entities;

namespace GameStore.DAL.UoW.Abstract
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly StoreDbContext _dbContext;

        public UnitOfWork(
            StoreDbContext dbContext,
            IGenericRepository<Game> gameRepository,
            IGenericRepository<Genre> genreRepository,
            IGenericRepository<PlatformType> platformTypeRepository,
            IGenericRepository<Comment> commentRepository,
            IGenericRepository<Publisher> publisherRepository,
            IGenericRepository<Order> orderRepository,
            IGenericRepository<OrderDetails> orderDetailsRepository,
            IGenericRepository<User> loginRepository,
            IGenericRepository<UserRefreshToken> refreshTokenRepository)              
        {
            _dbContext = dbContext;
            GameRepository = gameRepository;
            GenreRepository = genreRepository;
            PlatformTypeRepository = platformTypeRepository;
            CommentRepository = commentRepository;
            PublisherRepository = publisherRepository;
            OrderRepository = orderRepository;
            OrderDetailsRepository = orderDetailsRepository;
            UserRepository = loginRepository;
            RefreshTokenRepository = refreshTokenRepository;
        }

        public IGenericRepository<Game> GameRepository { get; }

        public IGenericRepository<Genre> GenreRepository { get; }

        public IGenericRepository<PlatformType> PlatformTypeRepository { get; }

        public IGenericRepository<Comment> CommentRepository { get; }

        public IGenericRepository<Publisher> PublisherRepository { get; }

        public IGenericRepository<Order> OrderRepository { get; }

        public IGenericRepository<OrderDetails> OrderDetailsRepository { get; }

        public IGenericRepository<User> UserRepository { get; }

        public IGenericRepository<UserRefreshToken> RefreshTokenRepository { get; }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
