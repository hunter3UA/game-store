using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GameStore.BLL.DTO;
using GameStore.BLL.DTO.Platform;
using GameStore.BLL.DTO.PlatformType;
using GameStore.BLL.Enums;
using GameStore.BLL.Providers;
using GameStore.BLL.Services.Abstract;
using GameStore.DAL.Entities.Platforms;
using GameStore.DAL.UoW.Abstract;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;

namespace GameStore.BLL.Services.Implementation
{
    public class PlatformTypeService : IPlatformTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<PlatformTypeService> _logger;
        private readonly IMongoLoggerProvider _mongoLogger;

        public PlatformTypeService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<PlatformTypeService> logger, IMongoLoggerProvider mongoLogger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _mongoLogger = mongoLogger;
        }

        public async Task<PlatformTypeDTO> AddPlatformAsync(AddPlatformTypeDTO addPlatformDTO)
        {
            PlatformType mappedPlatform = _mapper.Map<PlatformType>(addPlatformDTO);

            PlatformType addedPlatform = await _unitOfWork.PlatformTypeRepository.AddAsync(mappedPlatform);
            await _unitOfWork.SaveAsync();

            _logger.LogInformation($"Platform with Id {addedPlatform.Id} has been added");
            await _mongoLogger.LogInformation<PlatformType>(ActionType.Create);

            return _mapper.Map<PlatformTypeDTO>(addedPlatform);
        }

        public async Task<List<PlatformTypeDTO>> GetListOfPlatformsAsync()
        {
            var allPlatforms = await _unitOfWork.PlatformTypeRepository.GetListAsync(t => t.Translations);

            return _mapper.Map<List<PlatformTypeDTO>>(allPlatforms);
        }

        public async Task<PlatformTypeDTO> GetPlatformAsync(int id)
        {
            var searchedPlatform = await _unitOfWork.PlatformTypeRepository.GetAsync(p => p.Id == id, p => p.Translations);

            return searchedPlatform != null ? _mapper.Map<PlatformTypeDTO>(searchedPlatform) : throw new KeyNotFoundException("Platform not found");
        }

        public async Task<PlatformTypeDTO> UpdatePlatformAsync(UpdatePlatformTypeDTO updatePlatformDTO)
        {
            PlatformType mappedPlatform = _mapper.Map<PlatformType>(updatePlatformDTO);

            PlatformType oldPlatform = await _unitOfWork.PlatformTypeRepository.GetAsync(p => p.Id == updatePlatformDTO.Id);
            var oldVersion = mappedPlatform.ToBsonDocument();
            PlatformType updatedPlatform = await _unitOfWork.PlatformTypeRepository.UpdateAsync(mappedPlatform);
            await _unitOfWork.SaveAsync();

            if (updatedPlatform != null)
            {
                _logger.LogInformation($"Platform with Id {updatedPlatform.Id} has been updated");
                await _mongoLogger.LogInformation<PlatformType>(ActionType.Update, oldVersion, updatedPlatform.ToBsonDocument());
            }
            else
                throw new ArgumentException("Platform can not be updated");

            return _mapper.Map<PlatformTypeDTO>(updatedPlatform);
        }

        public async Task<bool> RemovePlatformAsync(int id)
        {
            bool isRemovedPlatform = await _unitOfWork.PlatformTypeRepository.RemoveAsync(p => p.Id == id);
            await _unitOfWork.SaveAsync();

            if (isRemovedPlatform)
            {
                _logger.LogInformation($"Platform with Id {id} has been deleted");
                await _mongoLogger.LogInformation<PlatformType>(ActionType.Delete);
            }
            else
                throw new ArgumentException("Platform can not be deleted");

            return isRemovedPlatform;
        }
    }
}
