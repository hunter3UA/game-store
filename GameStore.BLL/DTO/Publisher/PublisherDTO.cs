using GameStore.BLL.DTO.Game;
using System.Collections.Generic;

namespace GameStore.BLL.DTO.Publisher
{
    public class PublisherDTO
    {
        public int Id { get; set; }

        public string CompanyName { get; set; }

        public string Description { get; set; }

        public string HomePage { get; set; }

        List<GameDTO> Games { get; set; }
    }
}
