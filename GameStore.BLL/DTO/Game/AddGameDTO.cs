using System.ComponentModel.DataAnnotations;

namespace GameStore.BLL.DTO.Game
{
    public class AddGameDTO
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Key { get; set; }

        public int[] GenresId { get; set; }

        public int[] PlatformsId { get; set; }

        public decimal Price { get; set; }

        public bool Discountinued { get; set; }

        public short UnitsInStock { get; set; }

        public int? PublisherId { get; set; }
    }
}
