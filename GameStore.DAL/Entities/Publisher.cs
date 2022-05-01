using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.DAL.Entities
{
    [Index("CompanyName", IsUnique = true)]
    public class Publisher : BaseEntity
    {
        [Required, MaxLength(40)]
        public string CompanyName { get; set; }

        [Required, Column(TypeName = "ntext"), MaxLength(1000)]
        public string Description { get; set; }

        [Required, Column(TypeName = "ntext"), MaxLength(400)]
        public string HomePage { get; set; }

        public IEnumerable<Game> Games { get; set; }
    }
}
