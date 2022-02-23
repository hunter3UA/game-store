﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GameStore.BLL.DTO
{
    public class UpdateGameDTO
    {
        public Guid GameId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int[] GenresID { get; set; }
        public Guid[] PlatformsId { get; set; }
    }
}
