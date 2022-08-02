using GameStore.BLL.DTO.Auth;
using GameStore.BLL.Models;
using GameStore.BLL.Services.Abstract;
using GameStore.DAL.Entities;
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

        public async Task<AuthResponseDTO> GetJwtTokenAsync(AuthRequestDTO authRequestDTO)
        {
            User userByEmail = await _unitOfWork.UserRepository.GetAsync(u => u.Email == authRequestDTO.Email);
            if (userByEmail == null)
                throw new KeyNotFoundException("User does not exist");

            bool isCorrectPassword = _passwordService.CheckPassword(userByEmail, authRequestDTO.Password);
            if (!isCorrectPassword)
                throw new ArgumentException("Incorrect password");

            return await GenerateTokens(userByEmail);
        }

        public async Task<AuthResponseDTO> GetJwtTokenAsync(User user)
        {
            return await GenerateTokens(user);
        }

        public async Task<AuthResponseDTO> RefreshTokenAsync(RefreshTokenRequestDTO refreshTokenRequestDTO)
        {
            if (refreshTokenRequestDTO.ExpiredAccessToken == null)
                throw new ArgumentException("Expired token can not be null");
            if (refreshTokenRequestDTO.RefreshToken == null)
                throw new ArgumentException("Refresh token can not be null");

            var token = ReadJwtToken(refreshTokenRequestDTO.ExpiredAccessToken);
            var userRefreshToken = await _unitOfWork.RefreshTokenRepository.GetAsync(
                t => !t.IsInvalidated && t.Token == refreshTokenRequestDTO.ExpiredAccessToken &&
                t.RefreshToken == refreshTokenRequestDTO.RefreshToken, t => t.User);

            var authResponse = ValidateDetails(token, userRefreshToken);
            userRefreshToken.IsInvalidated = true;
            await _unitOfWork.SaveAsync();

            var response = await GetJwtTokenAsync(userRefreshToken.User);

            return response;
           
        }

        private async Task<AuthResponseDTO> SaveTokenDetailsAsync(User user, string accessToken, string refreshToken)
        {
            var userRefreshToken = new UserRefreshToken
            {
                ExpirationDate = DateTime.UtcNow.AddDays(7),
                IsInvalidated = false,
                RefreshToken = refreshToken,
                Token = accessToken,
                UserId = user.Id
            };

            await _unitOfWork.RefreshTokenRepository.AddAsync(userRefreshToken);
            await _unitOfWork.SaveAsync();

            return new AuthResponseDTO { Token = accessToken, RefreshToken = refreshToken, IsSuccess = true };
        }

        private async Task<AuthResponseDTO> GenerateTokens(User userByEmail)
        {
            var refreshToken = GenerateRefreshToken();
            var accessToken = GenerateAccessToken(userByEmail);
            return await SaveTokenDetailsAsync(userByEmail, accessToken, refreshToken);
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
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(descriptor);
            string tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }

        private string GenerateRefreshToken()
        {
            var byteArray = new byte[64];
            using (var cryptoProvider = new RNGCryptoServiceProvider())
            {
                cryptoProvider.GetBytes(byteArray);
             
                return Convert.ToBase64String(byteArray);
            }
        }

        public JwtSecurityToken ReadJwtToken(string expiredToken)
        {
            var securityTokenHandler = new JwtSecurityTokenHandler();

            return securityTokenHandler.ReadJwtToken(expiredToken);
        }

        private AuthResponseDTO ValidateDetails(JwtSecurityToken token, UserRefreshToken userRerfreshToken)
        {
            if (userRerfreshToken == null)
                throw new ArgumentException("Invalid token details");
            if (token.ValidTo > DateTime.UtcNow)
                throw new ArgumentException("Access token is not expired");
            if (!userRerfreshToken.IsActive)
                throw new ArgumentException("Refresh token is expired");

            return new AuthResponseDTO { IsSuccess = true };
        }
    }
}
