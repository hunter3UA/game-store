﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GameStore.BLL.DTO.Publisher;
using GameStore.BLL.Services.Abstract;
using GameStore.DAL.Entities;
using GameStore.DAL.UoW.Abstract;
using Microsoft.Extensions.Logging;

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

            _logger.LogInformation($"Publisher with Id {addedPublisher.Id} has been added");

            return _mapper.Map<PublisherDTO>(addedPublisher);
        }

        public async Task<List<PublisherDTO>> GetListOfPublishersAsync()
        {
            List<Publisher> allPublishers = await _unitOfWork.PublisherRepository.GetListAsync(p => p.Games);

            return _mapper.Map<List<PublisherDTO>>(allPublishers);
        }

        public async Task<PublisherDTO> GetPublisherAsync(int id)
        {
            Publisher searchedPublisher = await _unitOfWork.PublisherRepository.GetAsync(p => p.Id == id);

            return searchedPublisher != null ? _mapper.Map<PublisherDTO>(searchedPublisher) : throw new KeyNotFoundException("Publisher not found");
        }

        public async Task<PublisherDTO> UpdatePublisherAsync(UpdatePublisherDTO updatePublisherDTO)
        {
            Publisher mappedPublisher = _mapper.Map<Publisher>(updatePublisherDTO);

            Publisher updatedPublisher = await _unitOfWork.PublisherRepository.UpdateAsync(mappedPublisher);
            await _unitOfWork.SaveAsync();

            if (updatedPublisher != null)
                _logger.LogInformation($"Publisher with Id:{updatedPublisher.Id} has been updated");
            else
                throw new ArgumentException("Publisher can not be updated");

            return _mapper.Map<PublisherDTO>(updatedPublisher);
        }

        public async Task<bool> RemovePublisherAsync(int id)
        {
            bool isDeletedPublisher = await _unitOfWork.PublisherRepository.RemoveAsync(p => p.Id == id);
            await _unitOfWork.SaveAsync();

            if (isDeletedPublisher)
                _logger.LogInformation($"Publisher with Id: {id} has been deleted");
            else
                throw new ArgumentException("Publisher can not be deleted");

            return isDeletedPublisher;
        }
    }
}
