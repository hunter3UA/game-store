using GameStore.DAL.Entities.GameStore;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.DAL.Entities.Platforms
{
    public class PlatformTypeTranslate : BaseEntity
    {
        public int PlatformTypeId { get; set; }

        [ForeignKey(nameof(PlatformTypeId))]
        public PlatformType PlatformType { get; set; }

        public string Type { get; set; }

        public string Language { get; set; }

    }
}
