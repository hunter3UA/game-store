﻿using System.Collections.Generic;

namespace GameStore.BLL.DTO.Comment
{
    public class CommentDTO
    {
        public int Id { get; set; }
   
        public string Name { get; set; }
  
        public string Body { get; set; }

        public int? ParentCommentId { get; set; }

        public List<CommentDTO> Answers { get; set; }   

        public bool IsQuote { get; set; }

        public bool IsDeleted { get; set; }
    }
}
