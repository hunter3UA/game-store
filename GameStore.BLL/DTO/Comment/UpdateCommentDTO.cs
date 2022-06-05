namespace GameStore.BLL.DTO.Comment
{
    public class UpdateCommentDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Body { get; set; }

        public int? ParentCommentId { get; set; }

        public bool IsQuote { get; set; }
    }
}
