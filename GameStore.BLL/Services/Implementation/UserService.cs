using AutoMapper;
using GameStore.BLL.DTO.Auth;
using GameStore.BLL.DTO.User;
using GameStore.BLL.Models;
using GameStore.BLL.Services.Abstract;
using GameStore.DAL.Entities;
using GameStore.DAL.Enums;
using GameStore.DAL.UoW.Abstract;
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

        public UserService(IUnitOfWork unitOfWork, IMapper mapper,IPasswordService passwordService,IAuthenticationService authService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _passwordService = passwordService;
            _authService = authService;
        }

        public async Task<AuthResponseDTO> RegisterUserAsync(RegisterDTO registerDTO)
        {
            User newUser = _mapper.Map<User>(registerDTO);

            SaltedHash saltedHash = _passwordService.CreateSaltedHash(registerDTO.Password, 24);
            newUser.PasswordHash = saltedHash.Hash;
            newUser.PasswordSalt = saltedHash.Salt;
            newUser.Role = Role.User.ToString();

            User addedUser = await _unitOfWork.UserRepository.AddAsync(newUser);
            await _unitOfWork.SaveAsync();

            var authRequest = new AuthRequestDTO { Email = newUser.Email, Password = registerDTO.Password };
            var response = await _authService.GetJwtTokenAsync(authRequest);

            return response;
        }

        public async Task<UserDTO> GetUserAsync(string email)
        {
            User userByEmail = await _unitOfWork.UserRepository.GetAsync(u => u.Email == email && !u.IsDeleted);

            return _mapper.Map<UserDTO>(userByEmail);
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
    }
}
