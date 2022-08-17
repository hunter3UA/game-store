using AutoFixture.Xunit2;
using FluentAssertions;
using GameStore.API.Controllers;
using GameStore.BLL.DTO.User;
using GameStore.BLL.Services.Abstract;
using GameStore.Tests.Attributes;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace GameStore.Tests.Controllers
{
    public class UsersControllerTests
    {
        [Theory, AutoDomainData]
        public void BanUser_UserIsBanned_ReturnOkResult([NoAutoProperties] UsersController commentController)
        {
            var result = commentController.BanUser();

            result.Should().BeOfType<OkResult>();
        }

        [Theory, AutoDomainData]
        public async Task GetAsync_RequestExistedUser_ReturnJsonResult([NoAutoProperties] UsersController usersController, [Frozen] Mock<IUserService> mockUserService)
        {
            mockUserService.Setup(m => m.GetUserAsync(It.IsAny<string>())).ReturnsAsync(new UserDTO());

            var result = await usersController.GetAsync("user");

            result.Should().BeOfType<JsonResult>();
        }

        [Theory, AutoDomainData]
        public async Task GetListAsync_RequestExistedList_ReturnJsonResult([NoAutoProperties] UsersController usersController, [Frozen] Mock<IUserService> mockUserService)
        {
            mockUserService.Setup(m => m.GetListOfUsersAsync()).ReturnsAsync(new List<UserDTO>());

            var result = await usersController.GetListAsync();

            result.Should().BeOfType<JsonResult>();
        }

        [Theory, AutoDomainData]
        public async Task UpdateAsync_GIvenValidUserToUpdate_ReturnJsonResult([NoAutoProperties] UsersController usersController, [Frozen] Mock<IUserService> mockUserService, UpdateUserDTO updateUserDTO)
        {
            mockUserService.Setup(m => m.UpdateUserAsync(It.IsAny<UpdateUserDTO>())).ReturnsAsync(new UserDTO());

            var result = await usersController.UpdateAsync(updateUserDTO);

            result.Should().BeOfType<JsonResult>();
        }
    }
}
