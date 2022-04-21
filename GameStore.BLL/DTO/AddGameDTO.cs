using System;
using System.Collections.Generic;
using System.Text;

namespace GameStore.BLL.DTO
{
    public class AddGameDTO
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Key { get; set; }

        public int[] GenresID { get; set; }

        public int[] PlatformsId { get; set; }
    }
}
