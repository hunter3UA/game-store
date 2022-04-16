using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GameStore.DAL.Entities
{
    public class PlatformsInGames
    {
        public int GameId { get; set; }
        [ForeignKey("GameId")]
        public Game Game { get; set; }
        public int PlatformTypeId { get; set; }
        [ForeignKey("PlatformTypeId")]
        public PlatformType PlatformType { get; set; }
    }
}
