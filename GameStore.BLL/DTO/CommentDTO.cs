using System;
using System.Collections.Generic;
using System.Text;

namespace GameStore.BLL.DTO
{
    public class CommentDTO
    {
        public int Id { get; set; }
   
        public string Name { get; set; }
  
        public string Body { get; set; }
        public List<CommentDTO> Answers { get; set; }
      
    }
}
