using System;
using System.Threading.Tasks;
using GameStore.DAL.Repositories.Abstract;
using GameStore.DAL.Context;
using GameStore.DAL.Entities.Games;
using GameStore.DAL.Entities.Platforms;
using GameStore.DAL.Entities.Genres;
using GameStore.DAL.Entities.Publishers;
using GameStore.DAL.Entities.GameStore;

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
            IUserRepository userRepository,
            IGenericRepository<PlatformTypeTranslate> platformTypeTranslateRepository,
            IGenericRepository<GenreTranslate> genreTranslateRepository,
            IGenericRepository<GameTranslate> gameTranslateRepository,
            IGenericRepository<PublisherTranslate> publisherTranslateRepository)
        {
            _dbContext = dbContext;
            GameRepository = gameRepository;
            GenreRepository = genreRepository;
            PlatformTypeRepository = platformTypeRepository;
            CommentRepository = commentRepository;
            PublisherRepository = publisherRepository;
            OrderRepository = orderRepository;
            OrderDetailsRepository = orderDetailsRepository;
            UserRepository = userRepository;
            PlatformTypeTranslateRepository = platformTypeTranslateRepository;
            GenreTranslateRepository = genreTranslateRepository;
            GameTranslateRepository = gameTranslateRepository;
            PublisherTranslateRepository = publisherTranslateRepository;
        }

        public IGenericRepository<Game> GameRepository { get; }

        public IGenericRepository<Genre> GenreRepository { get; }

        public IGenericRepository<PlatformType> PlatformTypeRepository { get; }

        public IGenericRepository<Comment> CommentRepository { get; }

        public IGenericRepository<Publisher> PublisherRepository { get; }

        public IGenericRepository<Order> OrderRepository { get; }

        public IGenericRepository<OrderDetails> OrderDetailsRepository { get; }

        public IUserRepository UserRepository { get; }

        public IGenericRepository<GameTranslate> GameTranslateRepository { get; }

        public IGenericRepository<GenreTranslate> GenreTranslateRepository { get; }

        public IGenericRepository<PlatformTypeTranslate> PlatformTypeTranslateRepository { get; }

        public IGenericRepository<PublisherTranslate> PublisherTranslateRepository { get; }


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
