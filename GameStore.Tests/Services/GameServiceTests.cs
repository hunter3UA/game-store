using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Community.AutoMapper;
using AutoFixture.Xunit2;
using AutoMapper;
using GameStore.BLL.DTO;
using GameStore.BLL.Mapper;
using GameStore.BLL.Services.Implementation;
using GameStore.DAL.Entities;
using GameStore.DAL.UoW.Abstract;
using GameStore.Tests.Attributes;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GameStore.Tests.Services
{
    public class GameServiceTests
    {
        [Theory, AutoDomainData]
        public async Task GetByKeyAsync_ShouldReturnGame_WhenGameExist(
             AddGameDTO gameToAddDto, [Frozen] IUnitOfWork unitOfWork,IHostEnvironment env, IMapper mapper, ILogger<GameService> logger)
        {
            GameService gm = new GameService(unitOfWork, env, logger, mapper);
            

            

            await gm.AddGameAsync(gameToAddDto);
            var list = await gm.GetListOfGamesAsync();

            
            int num = list.Count;
            Assert.Equal(0, num);

        }
        [Theory, AutoDomainData]
        public async Task GetByKeyAsync_ShouldReturnNull_WhenGameNotExsit([Frozen] Mock<IUnitOfWork> mockUnitOfWork, IMapper mapper, GameService gameService)
        {
            var count = await gameService.GetListOfGamesAsync();

            Assert.Equal(0, count.Count());
        }













    }
}
