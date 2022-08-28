using GameStore.DAL.Context.Abstract;
using GameStore.DAL.Entities.Games;
using GameStore.DAL.Entities.GameStore;
using GameStore.DAL.Entities.Genres;
using GameStore.DAL.Entities.Publishers;
using GameStore.DAL.Repositories.Abstract;

namespace GameStore.DAL.Context
{
    public class NorthwindFactory : INorthwindFactory
    {
        public NorthwindFactory(
            INorthwindGenericRepository<Game> products,
            INorthwindGenericRepository<Genre> categories,
            INorthwindGenericRepository<Order> orders,
            INorthwindGenericRepository<Publisher> suppliers,
            INorthwindGenericRepository<OrderDetails> orderDetails,
            INorthwindGenericRepository<Shipper> shippers,
            INorthwindLogRepository logs
            )
        {
            ProductRepository = products;
            CategoryRepository = categories;
            OrderRepository = orders;
            SupplierRepository = suppliers;
            OrderDetailsRepository = orderDetails;
            ShipperRepository = shippers;
            LogRepository = logs;
        }

        public INorthwindGenericRepository<Game> ProductRepository { get; }

        public INorthwindGenericRepository<Genre> CategoryRepository { get; }

        public INorthwindGenericRepository<Order> OrderRepository { get; }

        public INorthwindGenericRepository<Publisher> SupplierRepository { get; }

        public INorthwindGenericRepository<OrderDetails> OrderDetailsRepository { get; }

        public INorthwindGenericRepository<Shipper> ShipperRepository { get; }

        public INorthwindLogRepository LogRepository { get; }

    }
}
