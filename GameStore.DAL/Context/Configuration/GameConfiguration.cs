using GameStore.DAL.Entities.Games;
using GameStore.DAL.Entities.GameStore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameStore.DAL.Context.Configuration
{
    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
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

            builder.HasData(
                new Game { Id = 1, Name = "Stalker2", Key = "stalker-2", Description = "New part of Stalker", PublisherName = "GSC", UnitsInStock = 10, Price = 70, PublishedAt = DateTime.UtcNow.AddDays(-100) },
                new Game { Id = 2, Name = "Dying light", Key = "dying-light", Description = "Best part", PublisherName = "DeepSiler", UnitsInStock = 0, Price = 50, PublishedAt = DateTime.UtcNow.AddDays(-50) },
                new Game { Id = 3, Name = "Left 4 Dead", Key = "left-4-dead", Description = "Action ", PublisherName = "GSC", UnitsInStock = 3, Price = 100, PublishedAt = DateTime.UtcNow.AddDays(-400) },
                new Game { Id = 4, Name = "Call of Duty:MV", Key = "call-of-duty-mv", Description = "Description of cmv", PublisherName = "Activision", UnitsInStock = 5, Price = 30, PublishedAt = DateTime.UtcNow.AddDays(-7) },
                new Game { Id = 5, Name = "Sid Meier`s Civilization VI", Key = "civiization-VI", Description = "Description of civ", PublisherName = "Firaxis", UnitsInStock = 5, Price = 60, PublishedAt = DateTime.UtcNow.AddDays(-30) },
                new Game { Id = 6, Name = "Arma 3", Key = "arma-3", Description = "Description of arma", PublisherName = "Bohemia Interactive", UnitsInStock = 5, Price = 80, PublishedAt = DateTime.UtcNow.AddDays(-60) },
                new Game { Id = 7, Name = "Need for speed", Key = "nfs", Description = "Description of nfs", PublisherName = "GSC", UnitsInStock = 5, Price = 100, PublishedAt = DateTime.UtcNow.AddDays(-50) },
                new Game { Id = 8, Name = "Serious Sam 4", Key = "serious-sam-4", Description = "Description of Sam", PublisherName = "Activision", UnitsInStock = 5, Price = 45, PublishedAt = DateTime.UtcNow.AddDays(-15) },
                new Game { Id = 9, Name = "Sea of Thieves", Key = "sea-of-thieves", Description = "Description of Sea", PublisherName = "GSC", UnitsInStock = 5, Price = 90, PublishedAt = DateTime.UtcNow.AddDays(-50) },
                new Game { Id = 10, Name = "Battlefield 4", Key = "battlefield-4", Description = "Description of Battlefield", PublisherName = "Firaxis", UnitsInStock = 5, Price = 100, PublishedAt = DateTime.UtcNow.AddDays(-30) },
                new Game { Id = 11, Name = "Mass effect 1", Key = "mass-effect-1", Description = "Description of Mass effect 1", PublisherName = "DeepSiler", UnitsInStock = 5, Price = 50, PublishedAt = DateTime.UtcNow.AddDays(-20) },
                new Game { Id = 12, Name = "Command and conqurer", Key = "command-and-conqurer", Description = "Description of Command and conqurer", PublisherName = "Activision", UnitsInStock = 5, Price = 150, PublishedAt = DateTime.UtcNow.AddDays(-60) }
                );
        }
    }
}
