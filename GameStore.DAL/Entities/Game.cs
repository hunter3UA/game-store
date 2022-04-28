﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace GameStore.DAL.Entities
{
    [Index(nameof(Name), IsUnique = true)]
    [Index(nameof(Key), IsUnique = true)]
    public class Game : BaseEntity
    {
        [Required, MaxLength(500)]
        public string Key { get; set; }

        [Required, MaxLength(150)]
        public string Name { get; set; }

        [Required, MaxLength(5000)]
        public string Description { get; set; }

        public IEnumerable<Comment> Comments { get; set; }

        public IEnumerable<PlatformType> PlatformTypes { get; set; }

        public IEnumerable<Genre> Genres { get; set; }
    }
}