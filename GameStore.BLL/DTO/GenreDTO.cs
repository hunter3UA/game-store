using System;
using System.Collections.Generic;
using System.Text;

namespace GameStore.BLL.DTO
{
    public class GenreDTO
    {
        public int GenreId { get; set; }
        public string Name { get; set; }
        public List<GenreDTO> SubGenres { get; set; }
    }
}
