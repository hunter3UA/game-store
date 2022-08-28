using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using GameStore.BLL.DTO.Order;
using GameStore.BLL.DTO.OrderDetails;
using GameStore.BLL.Services.Implementation;
using GameStore.DAL.Entities;
using GameStore.DAL.Entities.Games;
using GameStore.DAL.Enums;
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
            Order orderOfDetails,
            [Frozen] Mock<IUnitOfWork> mockUnitOfWork,
            BasketService orderService)
        {
            detailsToAdd.GameKey = gameOfDetails.Key;
            mockUnitOfWork.Setup(m => m.OrderDetailsRepository.GetAsync(
                It.IsAny<Expression<Func<OrderDetails, bool>>>(),
                It.IsAny<Expression<Func<OrderDetails, object>>[]>())).ReturnsAsync(() => { return null; });
            mockUnitOfWork.Setup(m => m.OrderDetailsRepository.AddAsync(It.IsAny<OrderDetails>())).ReturnsAsync(() =>
            {
                return detailsToAdd;
            });

            mockUnitOfWork.Setup(m=>m.OrderRepository.GetAsync(It.IsAny<Expression<Func<Order, bool>>>())).ReturnsAsync(() =>
            {
                orderOfDetails.Status = OrderStatus.Opened;
                return orderOfDetails;
            });
          
            var result = await orderService.AddOrderDetailsAsync(gameOfDetails.Key, "1");

            result.Game.Key.Should().NotBeNullOrEmpty();
        }

        [Theory, AutoDomainData]
        public async Task AddOrderDetailsAsync_QuantityOfDetailsIsLessThen1_ReturnArgumentException(
           OrderDetails detailsToAdd,
           Game gameOfDetails,
           [Frozen] Mock<IUnitOfWork> mockUnitOfWork,
           BasketService orderService)
        {
            gameOfDetails.UnitsInStock = 0;
            detailsToAdd.GameKey = gameOfDetails.Key;

            mockUnitOfWork.Setup(m => m.GameRepository.GetAsync(
              It.IsAny<Expression<Func<Game, bool>>>(),
              It.IsAny<Expression<Func<Game, object>>[]>())).ReturnsAsync(() => { return gameOfDetails; });

            mockUnitOfWork.Setup(m => m.OrderDetailsRepository.GetAsync(
                It.IsAny<Expression<Func<OrderDetails, bool>>>(),
                It.IsAny<Expression<Func<OrderDetails, object>>[]>())).ReturnsAsync(() => { return null; });
            mockUnitOfWork.Setup(m => m.OrderDetailsRepository.AddAsync(It.IsAny<OrderDetails>())).ReturnsAsync(() =>
            {
                return detailsToAdd;
            });
            Exception result = await Record.ExceptionAsync(() => orderService.AddOrderDetailsAsync(gameOfDetails.Key, "1"));

            result.Should().BeOfType<ArgumentException>();
        }

        [Theory, AutoDomainData]
        public async Task AddOrderDetailsAsync_OrderWithThisGameAlreadyExist_ThrowArgumentException(
           Order orderOfDetails,
           OrderDetails detailsToAdd,
           Game gameOfDetails,
           [Frozen] Mock<IUnitOfWork> mockUnitOfWork,
           BasketService orderService)
        {
            gameOfDetails.UnitsInStock = 0;
            detailsToAdd.Game = gameOfDetails;

            mockUnitOfWork.Setup(m => m.OrderRepository.GetAsync(
              It.IsAny<Expression<Func<Order, bool>>>(),
              It.IsAny<Expression<Func<Order, object>>[]>())).ReturnsAsync(() => {
                  orderOfDetails.Status = OrderStatus.Processing;
                  return orderOfDetails; });

            mockUnitOfWork.Setup(m => m.OrderDetailsRepository.GetAsync(
                It.IsAny<Expression<Func<OrderDetails, bool>>>(),
                It.IsAny<Expression<Func<OrderDetails, object>>[]>())).ReturnsAsync(() => { return null; });
            mockUnitOfWork.Setup(m => m.OrderDetailsRepository.AddAsync(It.IsAny<OrderDetails>())).ReturnsAsync(() =>
            {
                return detailsToAdd;
            });
            Exception result = await Record.ExceptionAsync(() => orderService.AddOrderDetailsAsync(gameOfDetails.Key, "1"));

            result.Should().BeOfType<ArgumentException>();
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
        public async Task ChangeQuntityDetailsAsync_GivenInvalidOrderDetails_ThrowKeyNotFoundException( [Frozen]Mock<IUnitOfWork> mockUnitOfWork,
            BasketService orderService,
            ChangeQuantityDTO changeQuantityDTO   
            )
        {
            mockUnitOfWork.Setup(m => m.OrderDetailsRepository.GetAsync(
               It.IsAny<Expression<Func<OrderDetails, bool>>>(),
               It.IsAny<Expression<Func<OrderDetails, object>>[]>())).ReturnsAsync(() => { return null; });

            Exception result = await Record.ExceptionAsync(() => orderService.ChangeQuantityOfDetailsAsync(changeQuantityDTO));

            result.Should().BeOfType<KeyNotFoundException>();
        }


        [Theory, AutoDomainData]
        public async Task ChangeQuntityDetailsAsync_GivenOrderDetailsWithInvalidQuantity_ThrowKeyArgumentException([Frozen] Mock<IUnitOfWork> mockUnitOfWork,OrderDetails orderDetails,
           BasketService orderService,
           ChangeQuantityDTO changeQuantityDTO
           )
        {
            changeQuantityDTO.Quantity = -1;
            mockUnitOfWork.Setup(m => m.OrderDetailsRepository.GetAsync(
               It.IsAny<Expression<Func<OrderDetails, bool>>>(),
               It.IsAny<Expression<Func<OrderDetails, object>>[]>())).ReturnsAsync(() => { return orderDetails; });

            Exception result = await Record.ExceptionAsync(() => orderService.ChangeQuantityOfDetailsAsync(changeQuantityDTO));

            result.Should().BeOfType<ArgumentException>();
        }

        [Theory, AutoDomainData]
        public async Task GetOrderAsync_RequesteOrderExist_ReturnOrder(BasketService orderService)
        {
            var result = await orderService.GetBasketAsync("1");

            result.Should().BeOfType<OrderDTO>();
        }

        [Theory, AutoDomainData]
        public async Task GetOrderAsync_RequesteOrderNotExist_ReturnEmptyOrder([Frozen]Mock<IUnitOfWork> mockUnitOfWork,BasketService orderService)
        {
            mockUnitOfWork.Setup(m => m.OrderRepository.GetAsync(
            It.IsAny<Expression<Func<Order, bool>>>(),
            It.IsAny<Expression<Func<Order, object>>[]>())).ReturnsAsync(() => { return null; });

            var result =  await orderService.GetBasketAsync("1");
          
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
        public async Task RemoveOrderDetailsAsync_GivenInvalidId_ThrowArgumentException([Frozen] Mock<IUnitOfWork> mockUnitOfWork, BasketService orderService)
        {
            mockUnitOfWork.Setup(m => m.OrderDetailsRepository.RemoveAsync(It.IsAny<Expression<Func<OrderDetails, bool>>>())).ReturnsAsync(false);

            Exception result = await Record.ExceptionAsync(() => orderService.RemoveOrderDetailsAsync(1));

            result.Should().BeOfType<ArgumentException>();
        }
    }
}
