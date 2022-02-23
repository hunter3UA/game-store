using AutoMapper;
using GameStore.BLL.DTO;
using GameStore.BLL.Mapper;
using GameStore.BLL.Services.Abstract;
using GameStore.DAL.UoW;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.BLL.Services
{
    public class GenreService : IGenreService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GenreService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = AutoMapperConfig.Configure().CreateMapper();
        }
        public async Task<List<GenreDTO>> GetListAsync()
        {
            return _mapper.Map<List<GenreDTO>>(await _unitOfWork.GenreRepository.GetListAsync());
        }

      
    }
}
