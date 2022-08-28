using System.Collections.Generic;

namespace GameStore.BLL.DTO.Platform
{
    public class UpdatePlatformTypeDTO
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public List<PlatformTypeTranslateDTO> Translations { get; set; }
    }
}
