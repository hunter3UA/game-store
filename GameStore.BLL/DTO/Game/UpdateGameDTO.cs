using GameStore.DAL.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace GameStore.BLL.DTO.Game
{
    public class UpdateGameDTO
    {

        public string Name { get; set; }

        public string Key { get; set; }

        public string Description { get; set; }

        public bool Discontinued { get; set; }

        public short UnitsInStock { get; set; }

        public int[] GenresId { get; set; }

        public int[] PlatformsId { get; set; }

        public string PublisherName { get; set; }

        public decimal Price { get; set; }

        public string PublishedAt { get; set; }

        public int NumberOfViews { get; set; }

        public string QuantityPerUnit { get; set; }

    }
}
