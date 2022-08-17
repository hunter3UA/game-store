using System.Threading.Tasks;
using GameStore.DAL.Entities;
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


        IUserRepository UserRepository { get; }

        Task SaveAsync();
    }
}
