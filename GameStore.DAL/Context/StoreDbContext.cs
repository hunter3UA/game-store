using GameStore.DAL.Entities;
using GameStore.DAL.Static;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using System;

namespace GameStore.DAL.Context
{
    public class StoreDbContext : DbContext
    {
        public DbSet<Game> Games { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<PlatformType> PlatformTypes { get; set; }

        public DbSet<GenresInGames> GenresInGames { get; set; }

        public DbSet<PlatformsInGames> PlatformsInGames { get; set; }

        public DbSet<Publisher> Publishers { get; set; }

        public DbSet<OrderDetails> OrderDetails { get; set; }

        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration dbConfig = new ConfigurationBuilder()
                .AddJsonFile(Constants.JsonConfigFile, false, true).Build();
            optionsBuilder.UseSqlServer(
                dbConfig.GetConnectionString(Constants.GameStoreDb));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>(GamesConfigure);
            modelBuilder.Entity<Genre>().HasQueryFilter(g => !g.IsDeleted);
            modelBuilder.Entity<PlatformType>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<Publisher>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<Order>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<OrderDetails>().HasQueryFilter(p => !p.IsDeleted);
            Initialize(modelBuilder);
        }

        private void GamesConfigure(EntityTypeBuilder<Game> builder)
        {
       
            builder
              .HasMany(g => g.PlatformTypes)
              .WithMany(p => p.Games)
              .UsingEntity<PlatformsInGames>(
                  pg => pg.HasOne(prop => prop.PlatformType).WithMany().HasForeignKey(prop => prop.PlatformTypeId),
                  pg => pg.HasOne(prop => prop.Game).WithMany().HasForeignKey(prop => prop.GameId),
                  pg =>
                  {
                      pg.HasKey(pg => new { pg.PlatformTypeId, pg.GameId });
                  });
            builder
                .HasMany(gm => gm.Genres)
                .WithMany(gn => gn.Games)
                .UsingEntity<GenresInGames>(
                    gg => gg.HasOne(prop => prop.Genre).WithMany().HasForeignKey(prop => prop.GenreId),
                    gg => gg.HasOne(prop => prop.Game).WithMany().HasForeignKey(prop => prop.GameId),
                    gg =>
                    {
                        gg.HasKey(gg => new { gg.GenreId, gg.GameId });
                    });
        }

        private void Initialize(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Publisher>().HasData(
                new Publisher { Id = 1, CompanyName = "DeepSiler", Description = "Desc of Publisher 1 ", HomePage = "Home" },
                new Publisher { Id = 2, CompanyName = "GSC", Description = "Desc of Publisher 2 ", HomePage = "Home2" },
                new Publisher { Id = 3, CompanyName = "Activision", Description = "Desc of Activision", HomePage = "Activision page" },
                new Publisher { Id = 4, CompanyName = "Firaxis", Description = "Desc of Firaxis", HomePage = "Firaxis page" },
                new Publisher { Id = 5, CompanyName = "Bohemia Interactive", Description = "Desc of bohemia", HomePage = "Bohemia page" });
            modelBuilder.Entity<Genre>().HasData(
                new Genre { Id = 1, Name = "Strategy" },
                new Genre { Id = 2, Name = "RTS", ParentGenreId = 1 },
                new Genre { Id = 3, Name = "TBS", ParentGenreId = 1 },
                new Genre { Id = 4, Name = "RPG" },
                new Genre { Id = 5, Name = "Sports" },
                new Genre { Id = 6, Name = "Races" },
                new Genre { Id = 7, Name = "Rally", ParentGenreId = 6 },
                new Genre { Id = 8, Name = "Arcade", ParentGenreId = 6 },
                new Genre { Id = 9, Name = "Formula", ParentGenreId = 6 },
                new Genre { Id = 10, Name = "Off-road", ParentGenreId = 6 },
                new Genre { Id = 11, Name = "Action" },
                new Genre { Id = 12, Name = "FPS", ParentGenreId = 11 },
                new Genre { Id = 13, Name = "TPS", ParentGenreId = 11 },
                new Genre { Id = 14, Name = "Adventure" },
                new Genre { Id = 15, Name = "Puzzle & Skill" },
                new Genre { Id = 16, Name = "Misc" });
            modelBuilder.Entity<PlatformType>().HasData(
                new PlatformType { Id = 1, Type = "Mobile" },
                new PlatformType { Id = 2, Type = "Browser" },
                new PlatformType { Id = 3, Type = "Desktop" },
                new PlatformType { Id = 4, Type = "Console" });
            modelBuilder.Entity<Game>().HasData(
                new Game { Id = 1, Name = "Stalker2", Key = "stalker-2", Description = "New part of Stalker", PublisherName = "GSC", UnitsInStock = 10, Price = 70, PublishedAt = DateTime.UtcNow.AddDays(-100) },
                new Game { Id = 2, Name = "Dying light", Key = "dying-light", Description = "Best part", PublisherName = "DeepSiler", UnitsInStock = 0, Price = 50, PublishedAt = DateTime.UtcNow.AddDays(-50) },
                new Game { Id = 3, Name = "Left 4 Dead", Key = "left-4-dead", Description = "Action ", PublisherName = "GSC", UnitsInStock = 3, Price = 100, PublishedAt = DateTime.UtcNow.AddDays(-400) },
                new Game { Id = 4, Name = "Call of Duty:MV", Key = "call-of-duty-mv", Description = "Description of cmv", PublisherName = "Activision", UnitsInStock = 5, Price = 30, PublishedAt = DateTime.UtcNow.AddDays(-7) },
                new Game { Id = 5, Name = "Sid Meier`s Civilization VI", Key = "civiization-VI", Description = "Description of civ",  PublisherName = "Firaxis", UnitsInStock = 5, Price = 60, PublishedAt = DateTime.UtcNow.AddDays(-30) },
                new Game { Id = 6, Name = "Arma 3", Key = "arma-3", Description = "Description of arma",  PublisherName = "Bohemia Interactive", UnitsInStock = 5, Price = 80, PublishedAt = DateTime.UtcNow.AddDays(-60) },
                new Game { Id = 7, Name = "Need for speed", Key = "nfs", Description = "Description of nfs",  PublisherName = "GSC", UnitsInStock = 5, Price = 100, PublishedAt = DateTime.UtcNow.AddDays(-50) },
                new Game { Id = 8, Name = "Serious Sam 4", Key = "serious-sam-4", Description = "Description of Sam",  PublisherName = "Activision", UnitsInStock = 5, Price = 45, PublishedAt = DateTime.UtcNow.AddDays(-15) },
                new Game { Id = 9, Name = "Sea of Thieves", Key = "sea-of-thieves", Description = "Description of Sea",  PublisherName = "GSC", UnitsInStock = 5, Price = 90, PublishedAt = DateTime.UtcNow.AddDays(-50) },
                new Game { Id = 10, Name = "Battlefield 4", Key = "battlefield-4", Description = "Description of Battlefield", PublisherName = "Firaxis", UnitsInStock = 5, Price = 100, PublishedAt = DateTime.UtcNow.AddDays(-30) },
                new Game { Id = 11, Name = "Mass effect 1", Key = "mass-effect-1", Description = "Description of Mass effect 1", PublisherName = "DeepSiler", UnitsInStock = 5, Price = 50, PublishedAt = DateTime.UtcNow.AddDays(-20) },
                new Game { Id = 12, Name = "Command and conqurer", Key = "command-and-conqurer", Description = "Description of Command and conqurer", PublisherName= "Activision", UnitsInStock = 5, Price = 150, PublishedAt = DateTime.UtcNow.AddDays(-60) }
                );
            modelBuilder.Entity<GenresInGames>().HasData(
                new GenresInGames { GameId = 1, GenreId = 1 },
                new GenresInGames { GameId = 2, GenreId = 3 },
                new GenresInGames { GameId = 3, GenreId = 5 },
                new GenresInGames { GameId = 4, GenreId = 11 },
                new GenresInGames { GameId = 5, GenreId = 3 },
                new GenresInGames { GameId = 6, GenreId = 11 },
                new GenresInGames { GameId = 7, GenreId = 6 },
                new GenresInGames { GameId = 8, GenreId = 12 },
                new GenresInGames { GameId = 9, GenreId = 14 },
                new GenresInGames { GameId = 10, GenreId = 7 },
                new GenresInGames { GameId = 11, GenreId = 8 },
                new GenresInGames { GameId = 12, GenreId = 8 }
                );
            modelBuilder.Entity<PlatformsInGames>().HasData(
                new PlatformsInGames { GameId = 1, PlatformTypeId = 1 },
                new PlatformsInGames { GameId = 1, PlatformTypeId = 2 },
                new PlatformsInGames { GameId = 2, PlatformTypeId = 2 },
                new PlatformsInGames { GameId = 3, PlatformTypeId = 4 },
                new PlatformsInGames { GameId = 4, PlatformTypeId = 3 },
                new PlatformsInGames { GameId = 5, PlatformTypeId = 3 },
                new PlatformsInGames { GameId = 6, PlatformTypeId = 3 },
                new PlatformsInGames { GameId = 7, PlatformTypeId = 1 },
                new PlatformsInGames { GameId = 8, PlatformTypeId = 4 },
                new PlatformsInGames { GameId = 9, PlatformTypeId = 4 },
                new PlatformsInGames { GameId = 10, PlatformTypeId = 2 },
                new PlatformsInGames { GameId = 11, PlatformTypeId = 1 },
                new PlatformsInGames { GameId = 12, PlatformTypeId = 2 }
                );
            modelBuilder.Entity<Comment>().HasData(
                new Comment { Id = 1, Name = "Oleksandr", Body = "This is my favourite game", GameId = 1, },
                new Comment { Id = 2, Name = "Oleg", Body = "And my too", GameId = 1, ParentCommentId = 1 });
        }
    }
}



