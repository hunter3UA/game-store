using AutoFixture.Xunit2;
using FluentAssertions;
using GameStore.API.Controllers;
using GameStore.Tests.Attributes;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace GameStore.Tests.Controllers
{
    public class UsersControllerTests
    {
        [Theory, AutoDomainData]
        public void RemoveComment_UserIsBanned_ReturnOkResult([NoAutoProperties] UsersController commentController)
        {
            var result = commentController.BanUser();

            result.Should().BeOfType<OkResult>();
        }

    }
}
