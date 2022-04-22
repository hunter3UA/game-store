﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web.Http.Results;
using AutoFixture.Xunit2;
using AutoMapper;
using FluentAssertions;
using GameStore.API.Controllers;
using GameStore.BLL.DTO;
using GameStore.BLL.Services.Abstract;
using GameStore.DAL.Entities;
using GameStore.Tests.Attributes;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace GameStore.Tests.Controllers
{
    public class GameControllerTests
    {
        [Theory, AutoDomainData]
        public async Task AddGameAsync_GivenValidGame_ReturnGame(AddGameDTO addGameDTO, IMapper mapper,
        [Frozen] Mock<IGameService> mockGameService, [NoAutoProperties] GamesController gameController)
        {
            Game gameToAdd = mapper.Map<Game>(addGameDTO);
            mockGameService.Setup(m => m.AddGameAsync(It.IsAny<AddGameDTO>()))
                .ReturnsAsync(() =>
                {
                    return mapper.Map<GameDTO>(gameToAdd);
                });

            var result = await gameController.AddGameAsync(addGameDTO);

            result.Should().BeOfType<OkObjectResult>();
        }

        [Theory, AutoDomainData]
        public async Task GetListOfGamesAsync_RequestedListExist_ReturnOkResult([Frozen] Mock<IGameService> mockGameService,
         [NoAutoProperties] GamesController gamesController)
        {

            mockGameService.Setup(m => m.GetListOfGamesAsync()).ReturnsAsync(new List<GameDTO>());

            var result = await gamesController.GetListOfGamesAsync();

            result.Should().BeOfType<OkObjectResult>();
            
        }

        [Theory, AutoDomainData]
        public async Task GetGameAsync_GameExist_ReturnOkResult(Game game,IMapper mapper,
            [Frozen] Mock<IGameService> mockGameService,[NoAutoProperties] GamesController gamesController)
        {
            mockGameService.Setup(m => m.GetGameAsync(It.IsAny<Expression<Func<Game, bool>>>()))
                .ReturnsAsync(() => {
                    return mapper.Map<GameDTO>(game);
                });

            var result = await gamesController.GetGameAsync(game.Key);

            result.Should().BeOfType<OkObjectResult>();
        }

        [Theory,AutoDomainData]
        public async Task GetGameAsync_GameNotExist_ReturnNotFoundResult(
            [Frozen] Mock<IGameService> mockGameService,[NoAutoProperties] GamesController gamesController)
        {
            mockGameService.Setup(m => m.GetGameAsync(It.IsAny<Expression<Func<Game, bool>>>()))
                .ReturnsAsync(() => { return null; });

            var result = await gamesController.GetGameAsync("testKey");

            result.Should().BeOfType<Microsoft.AspNetCore.Mvc.NotFoundResult>();
                
        }
        
        [Theory,AutoDomainData]
        public async Task RemoveGameAsync_GameRemoved_ReturnOkResult(string key,
            [Frozen] Mock<IGameService> mockGameService,[NoAutoProperties] GamesController gamesController)
        {
            mockGameService.Setup(m => m.RemoveGameAsync(It.IsAny<string>())).ReturnsAsync(true);

            var result = await gamesController.RemoveGameAsync(key);

            result.Should().BeOfType<OkObjectResult>();
        }

        [Theory,AutoDomainData]
        public async Task UpdateGameAsync_GivenGameIsValid_ReturnOkResult(UpdateGameDTO updateGameDTO,
          [Frozen]Mock<IGameService> mockGameService,[NoAutoProperties] GamesController gamesController )
        {

            mockGameService.Setup(m => m.UpdateGameAsync(It.IsAny<UpdateGameDTO>())).ReturnsAsync(new GameDTO());

            var result = await gamesController.UpdateGameAsync(updateGameDTO);

            result.Should().BeOfType<OkObjectResult>();
        }
       
    }
}
