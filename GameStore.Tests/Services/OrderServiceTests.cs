using AutoFixture.Xunit2;
using FluentAssertions;
using GameStore.BLL.DTO.Order;
using GameStore.BLL.Services.Implementation;
using GameStore.DAL.Entities;
using GameStore.DAL.Enums;
using GameStore.DAL.UoW.Abstract;
using GameStore.Tests.Attributes;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;


namespace GameStore.Tests.Services
{
    public class OrderServiceTests
    {
        [Theory, AutoDomainData]
        public async Task MakeOrderAsync_GivenValidOrderId_ReturnOrder([Frozen] Mock<IUnitOfWork> mockUnitOfWOrk, OrderService orderService, IEnumerable<Game> games,Game game)
        {
            game.Price = 10;

            Order orderToUpdate = new Order()
            {
                OrderDate = DateTime.UtcNow,
                CustomerId = 1,
                OrderDetails = new List<OrderDetails>(),
                Expiration = DateTime.UtcNow.AddMinutes(60),
                Status = OrderStatus.Opened
            };
            orderToUpdate.Status = OrderStatus.Opened;
            List<OrderDetails> details = new List<OrderDetails>();
            foreach (var item in games)
            {
                item.Price = 10m;
             
              
                details.Add(new OrderDetails
                {
                    Id = 1,
                    GameKey = item.Key,
                    OrderId = orderToUpdate.Id,
                    Discount = 0,
                    Quantity = 1,
                    Price = item.Price,
                    IsDeleted = false
                });
            }
            orderToUpdate.OrderDetails = details;
            mockUnitOfWOrk.Setup(m=>m.GameRepository.GetAsync(It.IsAny<Expression<Func<Game, bool>>>(), It.IsAny<Expression<Func<Game, object>>[]>())).ReturnsAsync(() =>
            {
                return game;
            });
            mockUnitOfWOrk.Setup(m => m.OrderRepository.GetAsync(It.IsAny<Expression<Func<Order, bool>>>(), It.IsAny<Expression<Func<Order, object>>[]>())).ReturnsAsync(() =>
            {
                return orderToUpdate;
            });
            mockUnitOfWOrk.Setup(m => m.OrderRepository.UpdateAsync(
                It.IsAny<Order>(),
                It.IsAny<Expression<Func<Order, object>>[]>())).ReturnsAsync(() =>
                {

                    return orderToUpdate;
                });

            var result = await orderService.MakeOrderAsync(1);

            result.Should().BeOfType<OrderDTO>();
        }

        [Theory, AutoDomainData]
        public async Task MakeOrderAsync_GivenInValidOrder_ReturnKeyNotFoundException([Frozen] Mock<IUnitOfWork> mockUnitOfWOrk, OrderService orderService)
        {
            Order orderToUpdate = new Order()
            {
                OrderDate = DateTime.UtcNow,
                CustomerId = 1,
                OrderDetails = null,
                Expiration = DateTime.UtcNow.AddMinutes(60),
                Status = OrderStatus.Opened
            };

            mockUnitOfWOrk.Setup(m => m.OrderRepository.GetAsync(It.IsAny<Expression<Func<Order, bool>>>(), It.IsAny<Expression<Func<Order, object>>[]>())).ReturnsAsync(() =>
            {
                return null;
            });
            mockUnitOfWOrk.Setup(m => m.OrderRepository.UpdateAsync(
                It.IsAny<Order>(),
                It.IsAny<Expression<Func<Order, object>>[]>())).ReturnsAsync(() =>
                {

                    return orderToUpdate;
                });

            Exception result = await Record.ExceptionAsync(() => orderService.MakeOrderAsync(1));

            result.Should().BeOfType<KeyNotFoundException>();
        }

        [Theory, AutoDomainData]
        public async Task GetOrderAsync_GivenValidCustomerId_ReturnOrder([Frozen] Mock<IUnitOfWork> mockUnitOfWork, OrderService orderService, Order orderByCustomer)
        {
            mockUnitOfWork.Setup(m => m.OrderRepository.GetAsync(It.IsAny<Expression<Func<Order, bool>>>(), It.IsAny<Expression<Func<Order, object>>[]>())).ReturnsAsync(orderByCustomer);

            var result = await orderService.GetOrderAsync(1);

            result.Should().BeOfType<OrderDTO>();
        }

        [Theory, AutoDomainData]
        public async Task GetOrderAsync_GivenInValidCustomerId_ThrowKeyNotFoundException([Frozen] Mock<IUnitOfWork> mockUnitOfWork, OrderService orderService)
        {
            mockUnitOfWork.Setup(m => m.OrderRepository.GetAsync(It.IsAny<Expression<Func<Order, bool>>>(), It.IsAny<Expression<Func<Order, object>>[]>())).ReturnsAsync(() => { return null; });

            Exception result = await Record.ExceptionAsync(() => orderService.GetOrderAsync(1));

            result.Should().BeOfType<KeyNotFoundException>();
        }

        [Theory, AutoDomainData]
        public async Task CancelOrderAsync_GivenValidOrder_ReturnTrue([Frozen] Mock<IUnitOfWork> mockUnitOfWork, OrderService orderService, IEnumerable<Game> games)
        {
            Order orderToCanel = new Order()
            {
                OrderDate = DateTime.UtcNow,
                CustomerId = 1,
                OrderDetails = new List<OrderDetails>(),
                Expiration = DateTime.UtcNow.AddMinutes(60),
                Status = OrderStatus.Processing
            };
            orderToCanel.Status = OrderStatus.Opened;
            List<OrderDetails> details = new List<OrderDetails>();
            foreach (var item in games)
            {
                details.Add(new OrderDetails
                {
                    Id = 1,
                    GameKey = item.Key,
                    OrderId = orderToCanel.Id,
                    Discount = 0,
                    Quantity = 1,
                    Price = item.Price,
                    IsDeleted = false
                });
            }
            orderToCanel.OrderDetails = details;
            mockUnitOfWork.Setup(m => m.OrderRepository.GetAsync(It.IsAny<Expression<Func<Order, bool>>>(), It.IsAny<Expression<Func<Order, object>>[]>())).ReturnsAsync(() => { return orderToCanel; });

            var result = await orderService.CancelOrderAsync(1);

            result.Should().BeTrue();
        }

        [Theory, AutoDomainData]
        public async Task CancelOrderAsync_GivenInValidOrder_ThrowKeyNotFoundException([Frozen] Mock<IUnitOfWork> mockUnitOfWork, OrderService orderService)
        {
            mockUnitOfWork.Setup(m => m.OrderRepository.GetAsync(It.IsAny<Expression<Func<Order, bool>>>(), It.IsAny<Expression<Func<Order, object>>[]>())).ReturnsAsync(() => { return null; });

            Exception result = await Record.ExceptionAsync(() => orderService.CancelOrderAsync(1));

            result.Should().BeOfType<KeyNotFoundException>();
        }

        [Theory, AutoDomainData]
        public async Task UpdateOrderAsync_GivenValidOrder_ReturnOrder([Frozen] Mock<IUnitOfWork> mockUnitOfWork, OrderService orderService)
        {
            mockUnitOfWork.Setup(m => m.OrderRepository.UpdateAsync(It.IsAny<Order>(), It.IsAny<Expression<Func<Order, object>>[]>())).ReturnsAsync(new Order());

            var result = await orderService.UpdateOrderAsync(new UpdateOrderDTO());

            result.Should().BeOfType<OrderDTO>();
        }

        [Theory, AutoDomainData]
        public async Task UpdateOrderAsync_GivenNull_ThrowArgumentException([Frozen]Mock<IUnitOfWork> mockUnitOfWork,OrderService orderService)
        {
            Exception result = await  Record.ExceptionAsync(()=>orderService.UpdateOrderAsync(null));

            result.Should().BeOfType<ArgumentException>();
        }
    }
}
