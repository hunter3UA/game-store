using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using GameStore.BLL.DTO.Order;
using GameStore.BLL.DTO.OrderDetails;
using GameStore.BLL.Services.Implementation;
using GameStore.DAL.Entities;
using GameStore.DAL.UoW.Abstract;
using GameStore.Tests.Attributes;
using Moq;
using Xunit;

namespace GameStore.Tests.Services
{
    public class BasketServiceTests
    {
        [Theory, AutoDomainData]
        public async Task AddOrderDetailsAsync_GivenValidDetails_ReturnDetails(
            OrderDetails detailsToAdd,
            Game gameOfDetails,
            [Frozen] Mock<IUnitOfWork> mockUnitOfWork,
            BasketService orderService)
        {
            detailsToAdd.Game = gameOfDetails;
            mockUnitOfWork.Setup(m => m.OrderDetailsRepository.GetAsync(
                It.IsAny<Expression<Func<OrderDetails, bool>>>(),
                It.IsAny<Expression<Func<OrderDetails, object>>[]>())).ReturnsAsync(() => { return null; });
            mockUnitOfWork.Setup(m => m.OrderDetailsRepository.AddAsync(It.IsAny<OrderDetails>())).ReturnsAsync(() =>
            {
                return detailsToAdd;
            });

            var result = await orderService.AddOrderDetailsAsync(gameOfDetails.Key, 1);

            result.Game.Key.Should().BeEquivalentTo(gameOfDetails.Key);
        }

        [Theory, AutoDomainData]
        public async Task ChangeQuantityDetailsAsync_GivenValidData_ReturnOrderDetails(
            ChangeQuantityDTO changeQuantityDTO,
            BasketService orderService)
        {
            var result = await orderService.ChangeQuantityOfDetailsAsync(changeQuantityDTO);

            result.Should().BeOfType<OrderDetailsDTO>();
        }

        [Theory, AutoDomainData]
        public async Task ChangeQuntityDetailsAsync_GivenInvalidData_ReturnNull(
            BasketService orderService,
            ChangeQuantityDTO changeQuantityDTO)
        {
            changeQuantityDTO.Quantity = -1;

            var result = await orderService.ChangeQuantityOfDetailsAsync(changeQuantityDTO);

            result.Should().BeNull();
        }

        [Theory, AutoDomainData]
        public async Task GetOrderAsync_ReturnOrder(BasketService orderService)
        {
            var result = await orderService.GetBasketAsync(1);

            result.Should().BeOfType<OrderDTO>();
        }

        [Theory, AutoDomainData]
        public async Task RemoveOrderDetailsAsync_GivenValidId_ReturnTrue([Frozen] Mock<IUnitOfWork> mockUnitOfWork, BasketService orderService)
        {
            mockUnitOfWork.Setup(m => m.OrderDetailsRepository.RemoveAsync(It.IsAny<Expression<Func<OrderDetails, bool>>>())).ReturnsAsync(true);

            var result = await orderService.RemoveOrderDetailsAsync(1);

            result.Should().BeTrue();
        }

        [Theory, AutoDomainData]
        public async Task RemoveOrderDetailsAsync_GivenInvalidId_ReturnTrue([Frozen] Mock<IUnitOfWork> mockUnitOfWork, BasketService orderService)
        {
            mockUnitOfWork.Setup(m => m.OrderDetailsRepository.RemoveAsync(It.IsAny<Expression<Func<OrderDetails, bool>>>())).ReturnsAsync(false);

            var result = await orderService.RemoveOrderDetailsAsync(1);

            result.Should().BeFalse();
        }
    }
}
