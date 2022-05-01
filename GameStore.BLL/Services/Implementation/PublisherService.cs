using AutoMapper;
using GameStore.BLL.DTO.Publisher;
using GameStore.BLL.Services.Abstract;
using GameStore.DAL.Entities;
using GameStore.DAL.UoW.Abstract;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.BLL.Services.Implementation
{
    public class PublisherService : IPublisherService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<PublisherService> _logger;

        public PublisherService(IMapper mapper, IUnitOfWork unitOfWork, ILogger<PublisherService> logger)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<PublisherDTO> AddPublisherAsync(AddPublisherDTO addPublisherDTO)
        {
            Publisher mappedPublisher = _mapper.Map<Publisher>(addPublisherDTO);

            Publisher addedPublisher = await _unitOfWork.PublisherRepository.AddAsync(mappedPublisher);
            await _unitOfWork.SaveAsync();

            if (addedPublisher != null)
            {
                _logger.LogInformation($"Publisher with Id {addedPublisher.Id} has been added");
            }

            return _mapper.Map<PublisherDTO>(addedPublisher);
        }

        public async Task<List<PublisherDTO>> GetListOfPublishersAsync()
        {
            List<Publisher> allPublishers = await _unitOfWork.PublisherRepository.GetListAsync(p=>p.Games);

            return _mapper.Map<List<PublisherDTO>>(allPublishers);
        }

        public async Task<PublisherDTO> GetPublisherAsync(int id)
        {
            Publisher searchedPublisher = await _unitOfWork.PublisherRepository.GetAsync(p => p.Id == id);

            return _mapper.Map<PublisherDTO>(searchedPublisher);
        }

        public async Task<bool> RemovePublisherAsync(int id)
        {
            bool isDeletedPublisher = await _unitOfWork.PublisherRepository.RemoveAsync(p => p.Id == id);
            await _unitOfWork.SaveAsync();

            if (isDeletedPublisher)
            {
                _logger.LogInformation($"Publisher with Id: {id} has been deleted");
            }

            return isDeletedPublisher;
        }

        public Task<PublisherDTO> UpdatePublisherAsync(AddPublisherDTO updatePublisherDTO)
        {
            throw new System.NotImplementedException();
        }
    }
}
