using System;
using System.Collections.Generic;
using System.Text;

namespace GameStore.BLL.DTO
{
    public class AddCommentDTO
    {
        public string Name { get; set; }
      
        public string Body { get; set; }

        public Guid GameId { get; set; }

        public Guid? ParentCommentId { get; set; }
    }
}
