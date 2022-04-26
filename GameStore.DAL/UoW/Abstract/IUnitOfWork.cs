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

        Task SaveAsync();
    }
}
