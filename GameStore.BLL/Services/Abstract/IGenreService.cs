using System.Collections.Generic;
using System.Threading.Tasks;
using GameStore.BLL.DTO;
using GameStore.BLL.DTO.Genre;

namespace GameStore.BLL.Services.Abstract
{
    public interface IGenreService
    {
        Task<GenreDTO> AddGenreAsync(AddGenreDTO addGenreDTO);

        Task<List<GenreDTO>> GetListOfGenresAsync();

        Task<GenreDTO> GetGenreAsync(int id);

        Task<bool> RemoveGenreAsync(int id);
    }
}
