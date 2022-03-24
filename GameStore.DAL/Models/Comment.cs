using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.DAL.Models
{
    public class Comment
    {
        [Key]
        public Guid CommentId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Body { get; set; }
        [Column("fk_ParentId")]
        public Guid? ParentCommentId { get; set; }
        [ForeignKey("ParentCommentId")]
        public List<Comment> Answers { get; set; } = new List<Comment>();

        [Required, Column("fk_GameId")]
        public Guid GameId { get; set; }

        [Required, ForeignKey("GameId")]
        public Game Game { get; set; }

    }
}
