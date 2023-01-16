using GameStore.Common.Services.Abstract;
using GameStore.DAL.Context.Configuration;
using GameStore.DAL.Entities.Games;
using GameStore.DAL.Entities.GameStore;
using GameStore.DAL.Entities.Genres;
using GameStore.DAL.Entities.Platforms;
using GameStore.DAL.Entities.Publishers;
using GameStore.DAL.Static;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GameStore.DAL.Context
{
    public class StoreDbContext : DbContext
    {

        public IPasswordService _passwordService;

        public DbSet<Game> Games { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<PlatformType> PlatformTypes { get; set; }

        public DbSet<GenresInGames> GenresInGames { get; set; }

        public DbSet<PlatformsInGames> PlatformsInGames { get; set; }

        public DbSet<Publisher> Publishers { get; set; }

        public DbSet<OrderDetails> OrderDetails { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<GameTranslate> GameTranslates { get; set; }

        public DbSet<PlatformTypeTranslate> PlatformTypeTranslates { get; set; }

        public DbSet<GenreTranslate> GenreTranslates { get; set; }

        public DbSet<PublisherTranslate> PublisherTranslates { get; set; }


        public StoreDbContext(IPasswordService passwordService)
        {
            _passwordService = passwordService;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration dbConfig = new ConfigurationBuilder()
                .AddJsonFile(Constants.JsonConfigFile, false, true).Build();
            optionsBuilder.UseSqlServer(
                dbConfig.GetConnectionString(Constants.GameStoreDb));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GameConfiguration());
            modelBuilder.ApplyConfiguration(new GenreConfiguration());
            modelBuilder.ApplyConfiguration(new PlatformTypeConfiguration());
            modelBuilder.ApplyConfiguration(new GenresInGamesConfiguration());
            modelBuilder.ApplyConfiguration(new PlatformsInGamesConfiguration());
            modelBuilder.ApplyConfiguration(new PublisherConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration(_passwordService));
            modelBuilder.Entity<Order>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<OrderDetails>().HasQueryFilter(p => !p.IsDeleted);
        }
    }
}



