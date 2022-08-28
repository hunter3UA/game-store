using System.Collections.Generic;

namespace GameStore.BLL.DTO.Publisher
{
    public class AddPublisherDTO
    {
        public string CompanyName { get; set; }

        public string Description { get; set; }

        public string HomePage { get; set; }

        public List<PublisherTranslateDTO> Translations { get; set; }
    }
}
