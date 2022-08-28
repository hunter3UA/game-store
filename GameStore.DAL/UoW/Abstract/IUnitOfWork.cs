using System.Threading.Tasks;
using GameStore.DAL.Entities.Games;
using GameStore.DAL.Entities.GameStore;
using GameStore.DAL.Entities.Genres;
using GameStore.DAL.Entities.Platforms;
using GameStore.DAL.Entities.Publishers;
using GameStore.DAL.Repositories.Abstract;

namespace GameStore.DAL.UoW.Abstract
{
    public interface IUnitOfWork
    {
        IGenericRepository<Game> GameRepository { get; }

        IGenericRepository<Genre> GenreRepository { get; }

        IGenericRepository<PlatformType> PlatformTypeRepository { get; }

        IGenericRepository<Comment> CommentRepository { get; }

        IGenericRepository<Publisher> PublisherRepository { get; }

        IGenericRepository<Order> OrderRepository { get; }

        IGenericRepository<OrderDetails> OrderDetailsRepository { get; }

        IGenericRepository<GameTranslate> GameTranslateRepository { get; }

        IGenericRepository<GenreTranslate> GenreTranslateRepository { get; }

        IGenericRepository<PlatformTypeTranslate> PlatformTypeTranslateRepository { get; }

        IGenericRepository<PublisherTranslate> PublisherTranslateRepository { get; }

        IUserRepository UserRepository { get; }

        Task SaveAsync();
    }
}
