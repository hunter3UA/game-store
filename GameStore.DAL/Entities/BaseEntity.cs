using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GameStore.DAL.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required, DefaultValue(false)]
        public bool IsDeleted { get; set; } 
    }
}
