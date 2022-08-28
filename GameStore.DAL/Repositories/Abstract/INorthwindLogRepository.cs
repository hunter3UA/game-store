using GameStore.DAL.Entities.GameStore;
using System.Threading.Tasks;

namespace GameStore.DAL.Repositories.Abstract
{
    public interface INorthwindLogRepository
    {
        Task AddAsync(Log log);
    }
}
