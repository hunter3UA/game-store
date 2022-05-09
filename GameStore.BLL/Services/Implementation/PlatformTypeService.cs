using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using GameStore.BLL.DTO;
using GameStore.BLL.DTO.Platform;
using GameStore.BLL.DTO.PlatformType;
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

        public async Task<PlatformTypeDTO> AddPlatformAsync(AddPlatformTypeDTO addPlatformDTO)
        {
            PlatformType mappedPlatform = _mapper.Map<PlatformType>(addPlatformDTO);

            PlatformType addedPlatform = await _unitOfWork.PlatformTypeRepository.AddAsync(mappedPlatform);
            await _unitOfWork.SaveAsync();

            if (addedPlatform != null)
            {
                _logger.LogInformation($"Platform with Id {addedPlatform.Id} has been added");
            }

            return _mapper.Map<PlatformTypeDTO>(addedPlatform);
        }

        public async Task<List<PlatformTypeDTO>> GetListOfPlatformsAsync()
        {
            var allPlatforms = await _unitOfWork.PlatformTypeRepository.GetListAsync();

            return _mapper.Map<List<PlatformTypeDTO>>(allPlatforms);
        }

        public async Task<PlatformTypeDTO> GetPlatformAsync(int id)
        {
            var searchedPlatform = await _unitOfWork.PlatformTypeRepository.GetAsync(p=>p.Id==id);

            return _mapper.Map<PlatformTypeDTO>(searchedPlatform);
        }

        public async Task<bool> RemovePlatformAsync(int id)
        {
            bool isRemovedPlatform = await _unitOfWork.PlatformTypeRepository.RemoveAsync(p=>p.Id==id);
            await _unitOfWork.SaveAsync();

            if (isRemovedPlatform)
            {
                _logger.LogInformation($"Platform with Id {id} has been deleted");
            }

            return isRemovedPlatform;
        }

        public async Task<PlatformTypeDTO> UpdatePlatformAsync(UpdatePlatformTypeDTO updatePlatformDTO)
        {
            PlatformType mappedPlatform = _mapper.Map<PlatformType>(updatePlatformDTO);

            PlatformType updatedPlatform = await _unitOfWork.PlatformTypeRepository.UpdateAsync(mappedPlatform);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<PlatformTypeDTO>(updatedPlatform);
        }
    }
}
