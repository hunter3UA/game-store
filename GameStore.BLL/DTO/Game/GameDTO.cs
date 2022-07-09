using System;
using System.Collections.Generic;
using GameStore.BLL.DTO.Genre;
using GameStore.BLL.DTO.Publisher;
using GameStore.DAL.Entities;
using MongoDB.Bson;

namespace GameStore.BLL.DTO.Game
{
    public class GameDTO
    {
        public int Id { get; set; }

        public string ObjectId { get; set; }

        public string Name { get; set; }

        public string Key { get; set; }

        public string Description { get; set; }

        public List<GenreDTO> Genres { get; set; }

        public List<PlatformTypeDTO> PlatformTypes { get; set; }

        public PublisherDTO Publisher { get; set; }

        public decimal Price { get; set; }

        public bool Discontinued { get; set; }

        public short UnitsInStock { get; set; }

        public DateTime PublishedAt { get; set; }

        public int ReorderLevel { get; set; }

        public string QuantityPerUnit { get; set; }

        public bool IsSave { get; set; }

        public int NumberOfViews { get; set; }

        public TypeOfBase TypeOfBase { get; set; }
    }
}
