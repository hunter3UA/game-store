using System.Collections.Generic;

namespace GameStore.BLL.DTO.Genre
{
    public class GenreDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<GenreDTO> SubGenres { get; set; }

        public int ParentGenreId { get; set; }
    }
}
