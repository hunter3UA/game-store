using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.DAL.Entities
{
    public class Comment : BaseEntity
    {
        [Required,MinLength(1), MaxLength(150)]
        public string Name { get; set; }

        [Required,MinLength(1), MaxLength(10000)]
        public string Body { get; set; }

        public int? ParentCommentId { get; set; }

        [ForeignKey("ParentCommentId")]
        public IEnumerable<Comment> Answers { get; set; }

        [Required]
        public int? GameId { get; set; }

        [ForeignKey("GameId")]
        public Game Game { get; set; }

        [Required,DefaultValue(false)]
        public bool IsQuote { get; set; }
    }
}
