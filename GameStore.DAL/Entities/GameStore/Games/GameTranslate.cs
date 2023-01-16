using GameStore.DAL.Entities.GameStore;
using GameStore.DAL.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.DAL.Entities.Games
{
    public class GameTranslate: BaseEntity
    {
        [Required]
        public int GameId { get; set; }

        [ForeignKey(nameof(GameId))]
        public Game Game { get; set; }

        public string Name { get; set; }

        public string PublisherName { get; set; }

        public string Description { get; set; }

        public string QuantityPerUnit { get; set; }

        [Required]
        public string Language { get; set; }
    }
}
