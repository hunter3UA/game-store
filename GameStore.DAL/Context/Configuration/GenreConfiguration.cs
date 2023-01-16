using GameStore.DAL.Entities.Genres;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace GameStore.DAL.Context.Configuration
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasQueryFilter(g => !g.IsDeleted);
            var genres = new List<Genre>()
            {
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
            };
          
            builder.HasData(genres);
        }
    }
}
