using System.Collections.Generic;
using System.Threading.Tasks;
using GameStore.BLL.DTO.Game;

namespace GameStore.BLL.Services.Abstract
{
    public interface IGameService
    {
        Task<GameDTO> AddGameAsync(AddGameDTO gameToAddDTO);
        
        Task<List<GameDTO>> GetListOfGamesAsync();

        Task<GameDTO> GetGameAsync(string gameKey,bool isView);

        Task<bool> RemoveGameAsync(int id);

        Task<GameDTO> UpdateGameAsync(UpdateGameDTO updateGameDTO);

        Task<GamePageDTO> GetRangeOfGamesAsync(GameFilterDTO gameFilterDTO);
    }
}
