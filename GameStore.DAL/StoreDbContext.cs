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
        public DbSet<SubGenre> SubGenres { get; set; }
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
            modelBuilder.Entity<SubGenre>(SubGenresConfigure);
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
        public void SubGenresConfigure(EntityTypeBuilder<SubGenre> builder)
        {
            builder.HasData(
                new SubGenre { SubGenreId = Guid.NewGuid(), Name = "RTS", GenreId = 1 },
                new SubGenre { SubGenreId = Guid.NewGuid(), Name = "TBS", GenreId = 1 },
                new SubGenre { SubGenreId = Guid.NewGuid(), Name = "Rally", GenreId = 3 },
                new SubGenre { SubGenreId = Guid.NewGuid(), Name = "Arcade", GenreId = 3 },
                new SubGenre { SubGenreId = Guid.NewGuid(), Name = "Formula", GenreId = 3 },
                new SubGenre { SubGenreId = Guid.NewGuid(), Name = "Off-road", GenreId = 3 },
                new SubGenre { SubGenreId = Guid.NewGuid(), Name = "FPS", GenreId = 4 },
                new SubGenre { SubGenreId = Guid.NewGuid(), Name = "TPS", GenreId = 4 },
                new SubGenre { SubGenreId = Guid.NewGuid(), Name = "Misc", GenreId = 4 }
                );
        }
        public void GenreConfigure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasData(new Genre[]
            {
                new Genre{ GenreId=1, Name="Strategy"},
                new Genre{ GenreId=2, Name="Sports"},
                new Genre{ GenreId=3, Name="Races" },
                new Genre{ GenreId=4, Name="Action"},
                new Genre{ GenreId=5, Name="RPG"},               
                new Genre{ GenreId=6, Name="Adventure"},
                new Genre{ GenreId=7, Name="Puzzle & Skill"},
                new Genre{ GenreId=8, Name="Misc"}
            });
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
