using GameStore.DAL.Context.Abstract;
using GameStore.DAL.Context.Configuration;
using GameStore.DAL.Entities;
using GameStore.DAL.Static;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.DAL.Context
{
    public class StoreDbContext : DbContext
    {
        public INorthwindDbContext _northwindDbContext;
        public DbSet<Game> Games { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<PlatformType> PlatformTypes { get; set; }

        public DbSet<GenresInGames> GenresInGames { get; set; }

        public DbSet<PlatformsInGames> PlatformsInGames { get; set; }

        public DbSet<Publisher> Publishers { get; set; }

        public DbSet<OrderDetails> OrderDetails { get; set; }

        public DbSet<Order> Orders { get; set; }

        public StoreDbContext(INorthwindDbContext northwindDbContext)
        {
            _northwindDbContext = northwindDbContext;
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
            modelBuilder.ApplyConfiguration(new GenreConfiguration(_northwindDbContext));
            modelBuilder.ApplyConfiguration(new PlatformTypeConfiguration());
            modelBuilder.ApplyConfiguration(new GenresInGamesConfiguration());
            modelBuilder.ApplyConfiguration(new PlatformsInGamesConfiguration());
            modelBuilder.ApplyConfiguration(new PublisherConfiguration());      
            modelBuilder.Entity<Order>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<OrderDetails>().HasQueryFilter(p => !p.IsDeleted);
        }

       

   
    }
}



