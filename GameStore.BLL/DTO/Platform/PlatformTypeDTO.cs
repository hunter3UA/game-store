﻿using GameStore.BLL.DTO.Platform;
using System.Collections.Generic;

namespace GameStore.BLL.DTO
{
    public class PlatformTypeDTO
    {
        public int Id { get; set; }

        public string Type { get; set; }    

        public List<PlatformTypeTranslateDTO> Translations { get; set; }
    }
}
