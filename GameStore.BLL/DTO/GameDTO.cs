using System;
using System.Collections.Generic;
using System.Text;

namespace GameStore.BLL.DTO
{
    public class GameDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<GenreDTO> Genres { get; set; }
        public List<PlatformTypeDTO> PlatformTypes { get; set; }
    }
}
