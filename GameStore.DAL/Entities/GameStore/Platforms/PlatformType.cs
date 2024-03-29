﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GameStore.DAL.Entities.Games;
using GameStore.DAL.Entities.GameStore;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson.Serialization.Attributes;

namespace GameStore.DAL.Entities.Platforms
{
    [Index("Type", IsUnique = true)]
    public class PlatformType : BaseEntity
    {
        [Required, MaxLength(50)]
        public string Type { get; set; }

        public IEnumerable<Game> Games { get; set; }

        [BsonIgnore]
        public List<PlatformTypeTranslate> Translations { get; set; }
    }
}
