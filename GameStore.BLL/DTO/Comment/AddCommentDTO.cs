namespace GameStore.BLL.DTO.Comment
{
    public class AddCommentDTO
    {
        public string Name { get; set; }
      
        public string Body { get; set; }

        public int? ParentCommentId { get; set; }
    }
}
