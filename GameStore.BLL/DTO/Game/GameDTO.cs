using GameStore.BLL.DTO.Genre;
using System.Collections.Generic;

namespace GameStore.BLL.DTO.Game
{
    public class GameDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Key { get; set; }

        public string Description { get; set; }

        public List<GenreDTO> Genres { get; set; }

        public List<PlatformTypeDTO> PlatformTypes { get; set; }

        public decimal Price { get; set; }

        public bool Discounted { get; set; }

        public short UnitsInStock { get; set; }
    }
}
