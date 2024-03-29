﻿using System;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using AutoMapper;
using FluentAssertions;
using GameStore.API.Controllers;
using GameStore.BLL.DTO.Common;
using GameStore.BLL.DTO.Game;
using GameStore.BLL.Services.Abstract.Games;
using GameStore.DAL.Entities.Games;
using GameStore.Tests.Attributes;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace GameStore.Tests.Controllers
{
    public class GamesControllerTests
    {
        [Theory, AutoDomainData]
        public async Task AddGameAsync_GivenValidGame_ReturnJsonResult(
            AddGameDTO addGameDTO,
            IMapper mapper,
        [Frozen] Mock<IGameService> mockGameService,
        [NoAutoProperties] GamesController gameController)
        {
            addGameDTO.PublishedAt = DateTime.UtcNow.ToString();
            Game gameToAdd = mapper.Map<Game>(addGameDTO);
            mockGameService.Setup(m => m.AddGameAsync(It.IsAny<AddGameDTO>()))
                .ReturnsAsync(() =>
                {
                    return mapper.Map<GameDTO>(gameToAdd);
                });

            var result = await gameController.AddAsync(addGameDTO);

            result.Should().BeOfType<JsonResult>();
        }

        [Theory, AutoDomainData]
        public async Task GetListOfGamesAsync_RequestedListExist_ReturnJsonResult(
            [Frozen] Mock<IGameService> mockGameService,
            [NoAutoProperties] GamesController gamesController)
        {
            mockGameService.Setup(m => m.GetRangeOfGamesAsync(It.IsAny<GameFilterDTO>())).ReturnsAsync(new ItemPageDTO<GameDTO>());

            var result = await gamesController.GetRangeAsync(new GameFilterDTO());

            result.Should().BeOfType<JsonResult>();
        }

        [Theory,AutoDomainData]
        public async Task GetCountAsync_RequestedListExist_ReturnOkResult([NoAutoProperties] GamesController gamesController)
        {
            var result = await gamesController.GetCountAsync();

            result.Should().BeOfType<OkObjectResult>();
        }

        [Theory, AutoDomainData]
        public async Task GetGameAsync_RequestedGameExist_ReturnJsonResult(
            Game game,
            IMapper mapper,
            [Frozen] Mock<IGameService> mockGameService,
            [NoAutoProperties] GamesController gamesController)
        {
            mockGameService.Setup(m => m.GetGameAsync(It.IsAny<string>(),It.IsAny<bool>()))
                .ReturnsAsync(() =>
                {
                    return mapper.Map<GameDTO>(game);
                });

            var result = await gamesController.GetAsync(game.Key,false);

            result.Should().BeOfType<JsonResult>();
        }

        [Theory, AutoDomainData]
        public async Task RemoveGameAsync_RequestedGameRemoved_ReturnOkResult(
            string key,
            [Frozen] Mock<IGameService> mockGameService,
            [NoAutoProperties] GamesController gamesController)
        {
            mockGameService.Setup(m => m.RemoveGameAsync(It.IsAny<string>())).ReturnsAsync(true);

            var result = await gamesController.RemoveAsync(key);

            result.Should().BeOfType<OkResult>();
        }

        [Theory, AutoDomainData]
        public async Task UpdateGameAsync_GivenGameIsValid_ReturnJsonResult(
            UpdateGameDTO updateGameDTO,
          [Frozen] Mock<IGameService> mockGameService,
          [NoAutoProperties] GamesController gamesController)
        {
            mockGameService.Setup(m => m.UpdateGameAsync(It.IsAny<UpdateGameDTO>())).ReturnsAsync(new GameDTO());

            var result = await gamesController.UpdateAsync(updateGameDTO);

            result.Should().BeOfType<JsonResult>();
        }

        [Theory, AutoDomainData]
        public void DownloadGameFile_GivenKey_ReturnFile([NoAutoProperties] GamesController gamesController)
        {
            var result = gamesController.DownloadGameFile("key");

            result.Should().BeOfType<PhysicalFileResult>();
        }
    }
}
