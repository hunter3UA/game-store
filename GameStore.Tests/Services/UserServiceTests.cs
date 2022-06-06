using FluentAssertions;
using GameStore.BLL.Services.Abstract;
using GameStore.Tests.Attributes;
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
    }
}
