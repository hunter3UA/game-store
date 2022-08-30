
using GameStore.DAL.Entities.Northwind;
using GameStore.DAL.Entities.Publishers;
using GameStore.DAL.Repositories.Abstract;

namespace GameStore.DAL.Context.Abstract
{
    public interface INorthwindFactory
    {
        INorthwindGenericRepository<Product> ProductRepository { get; }

        INorthwindGenericRepository<Category> CategoryRepository { get; }

        INorthwindGenericRepository<Order> OrderRepository { get; }

        INorthwindGenericRepository<Supplier> SupplierRepository { get; }

        INorthwindGenericRepository<OrderDetails> OrderDetailsRepository { get; }

        INorthwindGenericRepository<Shipper> ShipperRepository { get; }

        INorthwindLogRepository LogRepository { get; }
    }
}
