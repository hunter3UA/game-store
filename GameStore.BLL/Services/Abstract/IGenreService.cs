using GameStore.BLL.DTO;
using GameStore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.BLL.Services.Abstract
{
    public interface IGenreService
    {
        Task<GenreDTO> AddGenreAsync(AddGenreDTO addGenreDTO);

        Task<List<GenreDTO>> GetListOfGenresAsync();

        Task<GenreDTO> GetGenreAsync(Expression<Func<Genre,bool>> predicate);

        Task<bool> RemoveGenreAsync(int key);
    }
}
