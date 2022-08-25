﻿using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.DAL.Entities
{
    public class GenresInGames
    {
        public int GenreId { get; set; }

        [ForeignKey(nameof(GenreId))]
        public Genre Genre { get; set; }

        public int GameId { get; set; }

        [ForeignKey(nameof(GameId))]
        public Game Game { get; set; }
    }
}
