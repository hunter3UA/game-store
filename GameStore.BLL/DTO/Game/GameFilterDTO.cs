using GameStore.BLL.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameStore.BLL.DTO.Game
{
    public class GameFilterDTO
    {
        public string Name { get; set; }

        public List<int> Genres { get; set; }

        public List<int> Platforms { get; set; }

        public List<int> Publishers { get; set; }

        public int? MinPrice { get; set; }

        public int? MaxPrice { get; set; }

        public int Page { get; set; } = 1;

        public int ElementsOnPage { get; set; } = 10;

        public SortingType SortingType { get; set; } = SortingType.Popularity;

        public PublishingDate? PublishingDate { get; set; }
    }
}
