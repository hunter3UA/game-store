using System.ComponentModel.DataAnnotations;

namespace GameStore.BLL.DTO.Game
{
    public class UpdateGameDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool Discountinued { get; set; }

        public short UnitsInStock { get; set; }

        public int[] Genres { get; set; }

        public int[] Platforms { get; set; }

        public int? PublisherId { get; set; }

        public decimal Price { get; set; }
    }
}
