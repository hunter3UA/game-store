﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.DAL.Entities
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        [Required,MaxLength(150)]
        public string Name { get; set; }
        [Required,MaxLength(10000)]
        public string Body { get; set; }
        public int? ParentCommentId { get; set; }
        [ForeignKey("ParentCommentId")]
        public List<Comment> Answers { get; set; }
        [Required]
        public int? GameId { get; set; }
        [Required, ForeignKey("GameId")]
        public Game Game { get; set; }
        [Required,DefaultValue(false)]
        public bool IsDeleted { get; set; }

        public Comment()
        {
            Answers = new List<Comment>();
        }

    }
}
