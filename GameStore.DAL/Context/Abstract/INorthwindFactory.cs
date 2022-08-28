using GameStore.DAL.Entities.Games;
using GameStore.DAL.Entities.GameStore;
using GameStore.DAL.Entities.Genres;
using GameStore.DAL.Entities.Publishers;
using GameStore.DAL.Repositories.Abstract;

namespace GameStore.DAL.Context.Abstract
{
    public interface INorthwindFactory
    {
        INorthwindGenericRepository<Game> ProductRepository { get; }

        INorthwindGenericRepository<Genre> CategoryRepository { get; }

        INorthwindGenericRepository<Order> OrderRepository { get; }

        INorthwindGenericRepository<Publisher> SupplierRepository { get; }

        INorthwindGenericRepository<OrderDetails> OrderDetailsRepository { get; }

        INorthwindGenericRepository<Shipper> ShipperRepository { get; }

        INorthwindLogRepository LogRepository { get; }
    }
}
