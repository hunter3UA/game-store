using System.Collections.Generic;
using System.Text.Json.Serialization;
using GameStore.BLL.DTO.Game;
using GameStore.DAL.Entities;
using GameStore.DAL.Enums;

namespace GameStore.BLL.DTO.Publisher
{
    public class PublisherDTO
    {
        public int Id { get; set; }

        public string CompanyName { get; set; }

        public string Description { get; set; }

        public string HomePage { get; set; }

        public string ContactName { get; set; }

        public string ContactTitle { get; set; }

        public string Address { get; set; }

        public string PostalCode { get; set; }

        public string Region { get; set; }

        public string City { get; set; }

        public string Phone { get; set; }

        public string Country { get; set; }

        public string Fax { get; set; }

        [JsonIgnore]
        public List<GameDTO> Games { get; set; }

        public TypeOfBase TypeOfBase { get; set; }

        public List<PublisherTranslateDTO> Translations { get; set; }
    }
}
