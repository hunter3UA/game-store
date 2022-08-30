using GameStore.DAL.Context.Abstract;
using GameStore.DAL.Repositories.Abstract;
using GameStore.DAL.Entities.Northwind;

namespace GameStore.DAL.Context
{
    public class NorthwindFactory : INorthwindFactory
    {
        public NorthwindFactory(
            INorthwindGenericRepository<Product> products,
            INorthwindGenericRepository<Category> categories,
            INorthwindGenericRepository<Order> orders,
            INorthwindGenericRepository<Supplier> suppliers,
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

        public INorthwindGenericRepository<Product> ProductRepository { get; }

        public INorthwindGenericRepository<Category> CategoryRepository { get; }

        public INorthwindGenericRepository<Order> OrderRepository { get; }

        public INorthwindGenericRepository<Supplier> SupplierRepository { get; }

        public INorthwindGenericRepository<OrderDetails> OrderDetailsRepository { get; }

        public INorthwindGenericRepository<Shipper> ShipperRepository { get; }

        public INorthwindLogRepository LogRepository { get; }

    }
}
