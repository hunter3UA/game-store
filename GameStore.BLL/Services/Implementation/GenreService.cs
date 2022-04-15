using AutoMapper;
using GameStore.BLL.DTO;
using GameStore.BLL.Mapper;
using GameStore.BLL.Services.Abstract;
using GameStore.DAL.Entities;
using GameStore.DAL.UoW;
using GameStore.DAL.UoW.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.BLL.Services.Implementation
{
    public class GenreService : IGenreService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GenreService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<GenreDTO>> GetListOfGenresAsync()
        {
            List<Genre> listOfGenres = await _unitOfWork.GenreRepository.GetListOfGenresAsync();
            return _mapper.Map<List<GenreDTO>>(listOfGenres);
        }

      
    }
}
