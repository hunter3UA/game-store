﻿using GameStore.DAL.Entities.Games;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.DAL.Entities.GameStore
{
    public class Comment : BaseEntity
    {
        [Required, MaxLength(150)]
        public string Name { get; set; }

        [Required, MaxLength(10000)]
        public string Body { get; set; }

        public int? ParentCommentId { get; set; }

        [ForeignKey(nameof(ParentCommentId))]
        public IEnumerable<Comment> Answers { get; set; }

        [Required]
        public int? GameId { get; set; }

        [ForeignKey(nameof(GameId))]
        public Game Game { get; set; }

        [Required, DefaultValue(false)]
        public bool IsQuote { get; set; }
    }
}
