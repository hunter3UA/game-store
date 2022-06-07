using System.Collections.Generic;

namespace GameStore.BLL.DTO.Game
{
    public class GamePageDTO
    {
        public PageInfoDTO PageInfo { get; set; }

        public List<GameDTO> Games { get; set; }
    }
}
