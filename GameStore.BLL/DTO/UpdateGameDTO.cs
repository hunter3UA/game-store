using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GameStore.BLL.DTO
{
    public class UpdateGameDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Key { get; set; }

        [Required]
        public int[] GenresId { get; set; }

        [Required]
        public int[] PlatformsId { get; set; }
    }
}
