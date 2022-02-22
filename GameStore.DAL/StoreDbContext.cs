using GameStore.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace GameStore.DAL
{
    public class StoreDbContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public DbSet<PlatformType> PlatformTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            IConfiguration dbConfig = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false, true).Build();
            optionsBuilder.UseSqlServer(
                dbConfig.GetConnectionString("GameStoreDb"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>(GameConfigure);
            modelBuilder.Entity<Genre>(GenreConfigure);
            modelBuilder.Entity<PlatformType>(PlatformTypeConfigure);

        }


        public void GameConfigure(EntityTypeBuilder<Game> builder)
        {
            builder
                .HasMany(g => g.PlatformTypes)
                .WithMany(p => p.Games)
                .UsingEntity(gp => gp.ToTable("GamePlatforms"));
            builder
                .HasMany(gn => gn.Genres)
                .WithMany(gm => gm.Games)
                .UsingEntity(gg => gg.ToTable("GameGenres"));
        }
        public void GenreConfigure(EntityTypeBuilder<Genre> builder)
        {

            builder.HasData(
                new Genre { GenreId = 1, Name = "Strategy" },
                new Genre { GenreId = 2, Name = "RTS", ParentGenreId = 1 },
                new Genre { GenreId = 3, Name = "TBS", ParentGenreId = 1 },
                new Genre { GenreId = 4, Name = "RPG" },
                new Genre { GenreId = 5, Name = "Sports" },
                new Genre { GenreId = 6, Name = "Races" },
                new Genre { GenreId = 7, Name = "Rally", ParentGenreId = 6 },
                new Genre { GenreId = 8, Name = "Arcade", ParentGenreId = 6 },
                new Genre { GenreId = 9, Name = "Formula", ParentGenreId = 6 },
                new Genre { GenreId = 10, Name = "Off-road", ParentGenreId = 6 },
                new Genre { GenreId = 11, Name = "Action" },
                new Genre { GenreId = 12, Name = "FPS", ParentGenreId = 11 },
                new Genre { GenreId = 13, Name = "TPS", ParentGenreId = 11 },
                new Genre { GenreId = 14, Name = "Misc", ParentGenreId = 11 },
                new Genre { GenreId = 15, Name = "Adventure" },
                new Genre { GenreId = 16, Name = "Puzzle & Skill" }
            );
        }
        public void PlatformTypeConfigure(EntityTypeBuilder<PlatformType> builder)
        {
            builder.HasData(
                new PlatformType { PlatformTypeId = Guid.NewGuid(), Type = "Mobile" },
                new PlatformType { PlatformTypeId = Guid.NewGuid(), Type = "Browser" },
                new PlatformType { PlatformTypeId = Guid.NewGuid(), Type = "Desktop" },
                new PlatformType { PlatformTypeId = Guid.NewGuid(), Type = "Console" }
                );
        }

    }
}
