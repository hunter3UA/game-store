using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GameStore.DAL.Entities
{
    [Index("CompanyName", IsUnique = true)]
    public class Publisher : BaseEntity
    {
        [Required, MaxLength(40)]
        public string CompanyName { get; set; }

        [Column(TypeName = "ntext"), MaxLength(1000)]
        public string Description { get; set; }

        [Required, Column(TypeName = "ntext"), MaxLength(400)]
        public string HomePage { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string ContactName { get; set; }

        public string ContactTitle { get; set; }

        public string Country { get; set; }

        public string Fax { get; set; }

        public string Phone { get; set; }

        public string PostalCode { get; set; }

        public IEnumerable<Game> Games { get; set; }
    }
}
