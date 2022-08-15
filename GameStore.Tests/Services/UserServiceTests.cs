using AutoFixture.Xunit2;
using FluentAssertions;
using GameStore.BLL.DTO.Auth;
using GameStore.BLL.DTO.User;
using GameStore.BLL.Models;
using GameStore.BLL.Services.Abstract;
using GameStore.BLL.Services.Implementation;
using GameStore.Common.Models;
using GameStore.Common.Services.Abstract;
using GameStore.DAL.Entities;
using GameStore.DAL.UoW.Abstract;
using GameStore.Tests.Attributes;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;

namespace GameStore.Tests.Services
{
    public class UserServiceTests
    {
        [Theory, AutoDomainData]
        public void BanUser_ReturnTrue(IUserService userService)
        {
            var result = userService.BanUser();

            result.Should().BeTrue();
        }

        [Theory, AutoDomainData]
        public async Task GetUserAsync_RequestedUserExist_ReturnUser([Frozen] Mock<IUnitOfWork> mockUnitOfWork, UserService userService, User user)
        {
            mockUnitOfWork.Setup(m => m.UserRepository.GetAsync(It.IsAny<Expression<Func<User, bool>>>())).ReturnsAsync(user);

            var result = await userService.GetUserAsync(user.UserName);

            result.UserName.Should().Be(user.UserName);
        }

        [Theory, AutoDomainData]
        public async Task GetUserAsync_RequestedUserNotExist_ThrowKeyNotFoundException([Frozen] Mock<IUnitOfWork> mockUnitOfWork, UserService userService)
        {
            mockUnitOfWork.Setup(m => m.UserRepository.GetAsync(It.IsAny<Expression<Func<User, bool>>>())).ReturnsAsync(() => { return null; });

            Exception exception = await Record.ExceptionAsync(() => userService.GetUserAsync("notExisted"));

            exception.Should().BeOfType<KeyNotFoundException>();
        }

        [Theory, AutoDomainData]
        public async Task RegisterUserAsync_GivenInvalidUser_ThrowArgumentException(UserService userService)
        {
            Exception exception = await Record.ExceptionAsync(() => userService.RegisterUserAsync(null));

            exception.Should().BeOfType<ArgumentException>();
        }

        [Theory, AutoDomainData]
        public async Task RegisterUserAsync_GivenValidUser_ReturnUser([Frozen] Mock<IUnitOfWork> mockUnitOfWork, [Frozen] Mock<IPasswordService> mockPasswordService, SaltedHash saltedHash, User userToAdd, UserService userService)
        {
            RegisterDTO registerDTO = new RegisterDTO() { Email = userToAdd.Email, Password = "password", UserName = userToAdd.UserName };

            mockPasswordService.Setup(m => m.CreateSaltedHash(It.IsAny<string>())).Returns(saltedHash);
            mockUnitOfWork.Setup(m => m.UserRepository.AddAsync(It.IsAny<User>())).ReturnsAsync(userToAdd);

            var result = await userService.RegisterUserAsync(registerDTO);

            result.Email.Should().Be(userToAdd.Email);
        }

        [Theory, AutoDomainData]
        public async Task GetListOfUsersAsync_RequestedListExist_ReturnListOfUsers([Frozen]Mock<IUnitOfWork> mockUnitOfWork, List<User> users,UserService userService)
        {
            mockUnitOfWork.Setup(m => m.UserRepository.GetListAsync()).ReturnsAsync(users);

            var result = await userService.GetListOfUsersAsync();

            result.Should().BeOfType<List<UserDTO>>();
        }

        [Theory,AutoDomainData]
        public async Task UpdateUserAsync_GivenNull_ThrowArgumentException(UserService userSerivce)
        {
            Exception result = await Record.ExceptionAsync(() => userSerivce.UpdateUserAsync(null));

            result.Should().BeOfType<ArgumentException>();
        }

        [Theory, AutoDomainData]
        public async Task UpdateUsersync_GivenValidUser_ReturnUser([Frozen]Mock<IUnitOfWork> mockUnitOfWork, User updatedUser, UserService userService)
        {
            UpdateUserDTO updateUserDTO = new UpdateUserDTO();
            updateUserDTO.UserName = "New Name";
            updateUserDTO.Role = updateUserDTO.Role;
            

            mockUnitOfWork.Setup(m => m.UserRepository.GetAsync(It.IsAny<Expression<Func<User, bool>>>())).ReturnsAsync(updatedUser);

            var result = await userService.UpdateUserAsync(updateUserDTO);

            result.UserName.Should().Be(updateUserDTO.UserName);
        }
    }
}
