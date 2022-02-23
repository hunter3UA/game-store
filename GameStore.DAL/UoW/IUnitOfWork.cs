using GameStore.DAL.Repositories.Abstract;
using System.Threading.Tasks;

namespace GameStore.DAL.UoW
{
    public interface IUnitOfWork
    {
        ICommentRepository CommentRepository { get; }
        IPlatformRepository PlatformRepository { get; }
        IGenreRepository GenreRepository { get; }
        IGameRepository GameRepository { get; }
        Task SaveAsync();
    }
}
