﻿using System.ComponentModel.DataAnnotations;

namespace GameStore.BLL.DTO
{
    public class AddGameDTO
    {
        public string Name { get; set; }

        public string Description { get; set; }
      
        public string Key { get; set; }

        [Required]
        public int[] GenresId { get; set; }

        [Required]
        public int[] PlatformsId { get; set; }
    }
}
