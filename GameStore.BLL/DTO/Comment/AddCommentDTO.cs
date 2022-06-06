using System.ComponentModel.DataAnnotations;

namespace GameStore.BLL.DTO.Comment
{
    public class AddCommentDTO
    {
        [StringLength(maximumLength: 150, MinimumLength = 5)]
        public string Name { get; set; }

        [StringLength(maximumLength: 10000, MinimumLength = 5)]
        public string Body { get; set; }

        public int? ParentCommentId { get; set; }

        public bool IsQuote { get; set; }
    }
}
