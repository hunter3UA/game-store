using GameStore.DAL.Entities.GameStore;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.DAL.Entities.Publishers
{
    public class PublisherTranslate : BaseEntity
    {
        public int PublisherId { get; set; }

        [ForeignKey(nameof(PublisherId))]
        public Publisher Publisher { get; set; }

        public string CompanyName { get; set; }

        public string Description { get; set; }

        public string HomePage { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string ContactName { get; set; }

        public string ContactTitle { get; set; }

        public string Country { get; set; }

        public string Region { get; set; }

        public string Language { get; set; }
    }
}
