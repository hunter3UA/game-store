using GameStore.DAL.Entities;
using GameStore.DAL.Repositories.Abstract;

namespace GameStore.DAL.Context.Abstract
{
    public interface INorthwindDbContext
    {
        INorthwindGenericRepository<Game> Products { get; }

        INorthwindGenericRepository<Genre> Categories { get; }

        INorthwindGenericRepository<Order> Orders { get; }
    }
}
