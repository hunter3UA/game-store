namespace GameStore.BLL.DTO.Genre
{
    public class AddGenreDTO
    {
        public string Name { get; set; }    

        public int? ParentGenreId { get; set; }
    }
}
