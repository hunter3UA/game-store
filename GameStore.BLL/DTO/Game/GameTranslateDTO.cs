using GameStore.DAL.Enums;
using System.ComponentModel.DataAnnotations;

namespace GameStore.BLL.DTO.Game
{
    public class GameTranslateDTO
    {
        [Required]
        public int GameId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string QuantityPerUnit { get; set; }

        public Language Language { get; set; }
    }
}
