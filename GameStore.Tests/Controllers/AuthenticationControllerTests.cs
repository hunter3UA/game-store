using AutoFixture.Xunit2;
using FluentAssertions;
using GameStore.API.Controllers;
using GameStore.BLL.DTO.Auth;
using GameStore.BLL.Services.Abstract;
using GameStore.Tests.Attributes;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace GameStore.Tests.Controllers
{
    public class AuthenticationControllerTests
    {

        [Theory, AutoDomainData]
        public async Task RegisterAsync_GivenValidUser_ReturnJsonResult([NoAutoProperties] AuthenticationController authenticationController,Mock<IAuthenticationService> mockAuthService,string jwtToken)
        {
            mockAuthService.Setup(m => m.GetJwtTokenAsync(It.IsAny<AuthRequestDTO>())).ReturnsAsync(jwtToken);

            var result = await authenticationController.RegisterAsync(new RegisterDTO());

            result.Should().BeOfType<JsonResult>();
        }


        [Theory, AutoDomainData]
        public async Task LoginAsync_GivenInValidUser_ReturnUnauthorizedResult([Frozen] Mock<IAuthenticationService> mockAuthService, [NoAutoProperties] AuthenticationController authenticationController, string jwtToken)
        {
            mockAuthService.Setup(m => m.GetJwtTokenAsync(It.IsAny<AuthRequestDTO>())).ReturnsAsync(() => { return null; });

            var result = await authenticationController.LoginAsync(new AuthRequestDTO());

            result.Should().BeOfType<UnauthorizedResult>();
        }

    }
}
