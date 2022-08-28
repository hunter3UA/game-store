using GameStore.DAL.Entities.GameStore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameStore.DAL.Context.Configuration
{
    public class GenresInGamesConfiguration : IEntityTypeConfiguration<GenresInGames>
    {
        public void Configure(EntityTypeBuilder<GenresInGames> builder)
        {
            builder.HasData(
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
        }
    }
}
