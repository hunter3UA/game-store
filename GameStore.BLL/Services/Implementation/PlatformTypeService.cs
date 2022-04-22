using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using GameStore.BLL.DTO;
using GameStore.BLL.Services.Abstract;
using GameStore.DAL.Entities;
using GameStore.DAL.UoW.Abstract;
using Microsoft.Extensions.Logging;

namespace GameStore.BLL.Services.Implementation
{
    public class PlatformTypeService : IPlatformTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<PlatformTypeService> _logger;

        public PlatformTypeService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<PlatformTypeService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<PlatformTypeDTO> AddPlatformTypeAsync(AddPlatformTypeDTO addPlatformDTO)
        {
            PlatformType platformToAdd = _mapper.Map<PlatformType>(addPlatformDTO);
            PlatformType addedPlatform = await _unitOfWork.PlatformTypeRepository.AddPlatformAsync(platformToAdd);
            await _unitOfWork.SaveAsync();

            if (addedPlatform != null)
            {
                _logger.LogInformation($"Platform with Id {addedPlatform.Id} has been added");
            }

            return _mapper.Map<PlatformTypeDTO>(addedPlatform);
        }

        public async Task<List<PlatformTypeDTO>> GetListOfPlatformsAsync()
        {
            var listOfPlatforms = await _unitOfWork.PlatformTypeRepository.GetListOfPlatformTypesAsync();

            return _mapper.Map<List<PlatformTypeDTO>>(listOfPlatforms);
        }

        public async Task<PlatformTypeDTO> GetPlatformAsync(Expression<Func<PlatformType, bool>> predicate)
        {
            var platformType = await _unitOfWork.PlatformTypeRepository.GetPlatformTypeAsync(predicate);

            return _mapper.Map<PlatformTypeDTO>(platformType);
        }

        public async Task<bool> RemovePlatformAsync(int id)
        {
            bool isRemovedPlatform = await _unitOfWork.PlatformTypeRepository.RemovePlatformAsync(id);
            await _unitOfWork.SaveAsync();

            if (isRemovedPlatform)
            {
                _logger.LogInformation($"Platform with Id {id} has been deleted");
            }

            return isRemovedPlatform;
        }
    }
}
