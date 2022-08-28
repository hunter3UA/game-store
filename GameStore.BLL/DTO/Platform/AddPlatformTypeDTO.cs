using GameStore.BLL.DTO.Platform;
using System.Collections.Generic;

namespace GameStore.BLL.DTO.PlatformType
{
    public class AddPlatformTypeDTO
    {
        public string Type { get; set; }    

        public List<PlatformTypeTranslateDTO> Translations { get; set; }
    }
}
