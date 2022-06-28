using GameStore.DAL.Context.Abstract;
using GameStore.DAL.Entities;
using GameStore.DAL.Repositories.Abstract;

namespace GameStore.DAL.Context
{
    public class NorthwindDbContext : INorthwindDbContext
    {
        public NorthwindDbContext(
            INorthwindGenericRepository<Game> products,
            INorthwindGenericRepository<Genre> categories,
            INorthwindGenericRepository<Order> orders
            )
        {
            Products = products;
            Categories = categories;
            Orders = orders;
        }

        public INorthwindGenericRepository<Game> Products { get; }

        public INorthwindGenericRepository<Genre> Categories { get; }

        public INorthwindGenericRepository<Order> Orders { get; }
    }
}
