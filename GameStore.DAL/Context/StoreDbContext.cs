﻿using GameStore.DAL.Entities;
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration dbConfig = new ConfigurationBuilder()
                .AddJsonFile(Constants.JSON_CONFIG_FILE, false, true).Build();
            optionsBuilder.UseSqlServer(
                dbConfig.GetConnectionString(Constants.DB_NAME));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>(GamesConfigure);
            modelBuilder.Entity<Comment>().HasQueryFilter(c => !c.IsDeleted);
            modelBuilder.Entity<Genre>().HasQueryFilter(g => !g.IsDeleted);
            modelBuilder.Entity<PlatformType>().HasQueryFilter(g => !g.IsDeleted);
            modelBuilder.Entity<PlatformType>().HasQueryFilter(p => !p.IsDeleted);
            Initialize(modelBuilder);
        }
        private void GamesConfigure(EntityTypeBuilder<Game> builder)
        {
            builder.HasQueryFilter(g => !g.IsDeleted);
            builder
              .HasMany(g => g.PlatformTypes)
              .WithMany(p => p.Games)
              .UsingEntity<PlatformsInGames>(
                  pg => pg.HasOne(prop => prop.PlatformType).WithMany().HasForeignKey(prop => prop.PlatformTypeId),
                  pg => pg.HasOne(prop => prop.Game).WithMany().HasForeignKey(prop => prop.GameId),
                  pg =>
                  {
                      pg.HasKey(pg => new { pg.PlatformTypeId, pg.GameId });
                  }
              );
            builder
                .HasMany(gm => gm.Genres)
                .WithMany(gn => gn.Games)
                .UsingEntity<GenresInGames>(
                    gg => gg.HasOne(prop => prop.Genre).WithMany().HasForeignKey(prop => prop.GenreId),
                    gg => gg.HasOne(prop => prop.Game).WithMany().HasForeignKey(prop => prop.GameId),
                    gg =>
                    {
                        gg.HasKey(gg => new { gg.GenreId, gg.GameId });
                    }
              );

        }

        private void Initialize(ModelBuilder modelBuilder)
        {
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
                new Genre { Id = 16, Name = "Misc" }
            );
            modelBuilder.Entity<PlatformType>().HasData(
                new PlatformType { Id = 1, Type = "Mobile" },
                new PlatformType { Id = 2, Type = "Browser" },
                new PlatformType { Id = 3, Type = "Desktop" },
                new PlatformType { Id = 4, Type = "Console" }
            );
            modelBuilder.Entity<Game>().HasData(
                new Game { Id = 1, Name = "Stalker2", Description = "New part of Stalker" },
                new Game { Id = 2, Name = "Dying ligth", Description = "Best part" },
                new Game { Id = 3, Name = "Left 4 Dead", Description = "Action " }
                );
            modelBuilder.Entity<GenresInGames>().HasData(
                new GenresInGames { GameId = 1, GenreId = 1 },
                new GenresInGames { GameId = 2, GenreId = 3 },
                new GenresInGames { GameId = 3, GenreId = 5 }
                );
            modelBuilder.Entity<PlatformsInGames>().HasData(
                new PlatformsInGames { GameId = 1, PlatformTypeId = 1 },
                new PlatformsInGames { GameId = 1, PlatformTypeId = 2 },
                new PlatformsInGames { GameId = 2, PlatformTypeId = 2 },
                new PlatformsInGames { GameId = 3, PlatformTypeId = 4 }
                );
            modelBuilder.Entity<Comment>().HasData(
                new Comment { Id = 1, Name = "Oleksandr", Body = "This is my favourite game", GameId = 1, },
                new Comment { Id = 2, Name = "Oleg", Body = "And my too", GameId = 1, ParentCommentId = 1 }
                );
        }

    }
}
