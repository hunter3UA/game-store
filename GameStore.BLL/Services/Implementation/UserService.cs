using AutoMapper;
using GameStore.BLL.DTO.Auth;
using GameStore.BLL.DTO.User;
using GameStore.BLL.Models;
using GameStore.BLL.Providers;
using GameStore.BLL.Services.Abstract;
using GameStore.Common.Models;
using GameStore.Common.Services.Abstract;
using GameStore.DAL.Entities;
using GameStore.DAL.Enums;
using GameStore.DAL.UoW.Abstract;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.BLL.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPasswordService _passwordService;
        private readonly IAuthenticationService _authService;
        private readonly ILogger<UserService> _logger;
        private readonly IMongoLoggerProvider _mongoLogger;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper, IPasswordService passwordService, IAuthenticationService authService,ILogger<UserService> logger,IMongoLoggerProvider mongoLogger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _passwordService = passwordService;
            _authService = authService;
            _logger = logger;
            _mongoLogger = mongoLogger;
        }

        public async Task<AuthRequestDTO> RegisterUserAsync(RegisterDTO registerDTO)
        {
            if (registerDTO == null)
                throw new ArgumentException();

            User newUser = _mapper.Map<User>(registerDTO);

            SaltedHash saltedHash = _passwordService.CreateSaltedHash(registerDTO.Password);
            newUser.PasswordHash = saltedHash.Hash;
            newUser.PasswordSalt = saltedHash.Salt;
            newUser.Role = Roles.User;

            User addedUser = await _unitOfWork.UserRepository.AddAsync(newUser);
            await _unitOfWork.SaveAsync();

            _logger.LogInformation($"User has been created with id:{addedUser.Id}");
            await _mongoLogger.LogInformation<User>(Enums.ActionType.Create);

            var authRequest = new AuthRequestDTO { Email = newUser.Email, Password = registerDTO.Password };
         
            return authRequest;

        }

        public async Task<UserDTO> GetUserAsync(string userName)
        {
            User userByEmail = await _unitOfWork.UserRepository.GetAsync(u => u.UserName == userName && !u.IsDeleted);

            return userByEmail != null ? _mapper.Map<UserDTO>(userByEmail) : throw new KeyNotFoundException();
        }

        public async Task<List<UserDTO>> GetListOfUsersAsync()
        {
            var users = await _unitOfWork.UserRepository.GetListAsync();

            return _mapper.Map<List<UserDTO>>(users);
        }

        public bool BanUser()
        {
            return true;
        }

        public async Task<UserDTO> UpdateUserAsync(UpdateUserDTO updateUserDTO)
        {
            if (updateUserDTO == null)
                throw new ArgumentException();

            User userById = await _unitOfWork.UserRepository.GetAsync(u => u.Id==updateUserDTO.Id);
            var oldVersion = userById.ToBsonDocument();

            userById.Role = updateUserDTO.Role;
            userById.UserName = updateUserDTO.UserName;

            await _unitOfWork.SaveAsync();

            var newVersion = userById.ToBsonDocument();
            _logger.LogInformation($"User has been updated with id:{userById.Id}");
            await _mongoLogger.LogInformation<User>(Enums.ActionType.Update, oldVersion, newVersion);
           
            return _mapper.Map<UserDTO>(userById);
        }
    }
}
