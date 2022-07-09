using System.Collections.Generic;
using System.Text.Json.Serialization;
using GameStore.BLL.DTO.Game;
using GameStore.DAL.Entities;

namespace GameStore.BLL.DTO.Publisher
{
    public class PublisherDTO
    {
        public int Id { get; set; }

        public string ObjectId { get; set; }

        public string CompanyName { get; set; }

        public string Description { get; set; }

        public string HomePage { get; set; }

        [JsonIgnore]
        public List<GameDTO> Games { get; set; }

        public TypeOfBase TypeOfBase { get; set; }
    }
}
