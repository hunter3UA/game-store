using GameStore.DAL.Entities.GameStore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.DAL.Entities.Genres
{
    public class GenreTranslate: BaseEntity
    {
        [Required]
        public int GenreId { get; set; }

        [ForeignKey(nameof(GenreId))]
        public Genre Genre { get; set; }

        public string Name { get; set; }

        public string Description { get; set; } 

        public string Language { get; set; }
    }
}
