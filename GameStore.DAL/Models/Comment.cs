using System;
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
        [Required]
        public int Level { get; set; } = -1;
        [Required]
        public bool IsAnsweread { get; set; }=false;
        public Guid AnswerTo { get; set; }
        [Required,Column("fk_GameId")]
        public Guid GameId { get; set; }
        [Required,ForeignKey("GameId")]
        public Game Game { get; set; }

    }
}
