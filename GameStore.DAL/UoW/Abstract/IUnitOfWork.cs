using System.Threading.Tasks;
using GameStore.DAL.Repositories.Abstract;

namespace GameStore.DAL.UoW.Abstract
{
    public interface IUnitOfWork
    {
        ICommentRepository CommentRepository { get; }
        IPlatformTypeRepository PlatformTypeRepository { get; }
        IGenreRepository GenreRepository { get; }
        IGameRepository GameRepository { get; }
        Task SaveAsync();
    }
}
