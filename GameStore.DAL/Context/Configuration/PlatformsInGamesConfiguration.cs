using GameStore.DAL.Entities.GameStore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameStore.DAL.Context.Configuration
{
    public class PlatformsInGamesConfiguration : IEntityTypeConfiguration<PlatformsInGames>
    {
        public void Configure(EntityTypeBuilder<PlatformsInGames> builder)
        {
            builder.HasData(
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
        }
    }
}
