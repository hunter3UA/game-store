using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GameStore.BLL.DTO.Game
{
    public class AddGameDTO
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Key { get; set; }

        public List<int> GenresId { get; set; }

        public List<int> PlatformsId { get; set; }

        public decimal Price { get; set; }

        public bool Discountinued { get; set; }

        public short UnitsInStock { get; set; }

        public string PublisherName { get; set; }

        public string PublishedAt { get; set; }

        public int NumberOfViews { get; set; }

        public string QuantityPerUnit { get; set; }
    }
}
