using GameStore.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.BLL.Services.Abstract
{
    public interface IGenreService
    {
        Task<List<GenreDTO>> GetListAsync();


    }
}
