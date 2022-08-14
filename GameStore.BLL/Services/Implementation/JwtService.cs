using GameStore.BLL.DTO.Auth;
using GameStore.BLL.Models;
using GameStore.BLL.Services.Abstract;
using GameStore.Common.Services.Abstract;
using GameStore.DAL.Entities;
using GameStore.DAL.Enums;
using GameStore.DAL.UoW.Abstract;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.BLL.Services.Implementation
{
    public class JwtService : IAuthenticationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordService _passwordService;

        public JwtService(IUnitOfWork unitOfWork, IPasswordService passwordService)
        {
            _unitOfWork = unitOfWork;
            _passwordService = passwordService;
        }

        public async Task<string> GetJwtTokenAsync(AuthRequestDTO authRequestDTO)
        {
            User userByEmail = await _unitOfWork.UserRepository.GetAsync(u => u.Email == authRequestDTO.Email);
            if (userByEmail == null)
                throw new KeyNotFoundException("User does not exist");

            bool isCorrectPassword = _passwordService.CheckPassword(userByEmail.PasswordHash, userByEmail.PasswordSalt, authRequestDTO.Password);
            if (!isCorrectPassword)
                throw new ArgumentException("Incorrect password");

            return GenerateAccessToken(userByEmail);
        }

        public JwtSecurityToken ReadJwtToken(string expiredToken)
        {
            var securityTokenHandler = new JwtSecurityTokenHandler();

            return securityTokenHandler.ReadJwtToken(expiredToken);
        }

        private string GenerateAccessToken(User userOfToken)
        {
            var symmetricSecurityKey = AuthOptions.GetSymmetricSecurityKey();

            var tokenHandler = new JwtSecurityTokenHandler();
            var descriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Sid,userOfToken.Id),
                    new Claim(ClaimTypes.Name, userOfToken.UserName),
                    new Claim(ClaimTypes.Email, userOfToken.Email),
                    new Claim(ClaimTypes.Role, userOfToken.Role.ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256)
            };

            if (userOfToken.Role == Roles.Publisher)
                descriptor.Subject.AddClaim(new Claim("PublisherName", userOfToken.PublisherName));

            var token = tokenHandler.CreateToken(descriptor);
            string tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }
    }
}
