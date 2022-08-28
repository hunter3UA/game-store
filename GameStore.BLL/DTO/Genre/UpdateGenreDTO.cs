using System.Collections.Generic;

namespace GameStore.BLL.DTO.Genre
{
    public class UpdateGenreDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? ParentGenreId { get; set; }

        public int CategoryId { get; set; }

        public List<GenreTranslateDTO> Translations { get; set; }   
    }
}
