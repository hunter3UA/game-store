using System.Collections.Generic;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using AutoMapper;
using FluentAssertions;
using GameStore.API.Controllers;
using GameStore.BLL.DTO;
using GameStore.BLL.DTO.Game;
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
        public async Task AddGameAsync_GivenValidGame_ReturnGame(
            AddGameDTO addGameDTO,
            IMapper mapper,
        [Frozen] Mock<IGameService> mockGameService,
        [NoAutoProperties] GamesController gameController)
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
        public async Task GetListOfGamesAsync_RequestedListExist_ReturnOkResult(
            [Frozen] Mock<IGameService> mockGameService,
            [NoAutoProperties] GamesController gamesController)
        {
            mockGameService.Setup(m => m.GetListOfGamesAsync()).ReturnsAsync(new List<GameDTO>());

            var result = await gamesController.GetListOfGamesAsync();

            result.Should().BeOfType<OkObjectResult>();
        }

        [Theory, AutoDomainData]
        public async Task GetGameAsync_GameExist_ReturnOkResult(
            Game game,
            IMapper mapper,
            [Frozen] Mock<IGameService> mockGameService,
            [NoAutoProperties] GamesController gamesController)
        {
            mockGameService.Setup(m => m.GetGameAsync(It.IsAny<string>()))
                .ReturnsAsync(() =>
                {
                    return mapper.Map<GameDTO>(game);
                });

            var result = await gamesController.GetGameAsync(game.Key);

            result.Should().BeOfType<OkObjectResult>();
        }

        [Theory, AutoDomainData]
        public async Task GetGameAsync_GameNotExist_ReturnNotFoundResult(
            [Frozen] Mock<IGameService> mockGameService, [NoAutoProperties] GamesController gamesController)
        {
            mockGameService.Setup(m => m.GetGameAsync(It.IsAny<string>()))
                .ReturnsAsync(() => { return null; });

            var result = await gamesController.GetGameAsync("testKey");

            result.Should().BeOfType<Microsoft.AspNetCore.Mvc.NotFoundResult>();
        }

        [Theory, AutoDomainData]
        public async Task RemoveGameAsync_GameRemoved_ReturnJsonResult(
            int id,
            [Frozen] Mock<IGameService> mockGameService,
            [NoAutoProperties] GamesController gamesController)
        {
            mockGameService.Setup(m => m.RemoveGameAsync(It.IsAny<int>())).ReturnsAsync(true);

            var result = await gamesController.RemoveGameAsync(id);

            result.Should().BeOfType<JsonResult>();
        }

        [Theory, AutoDomainData]
        public async Task UpdateGameAsync_GivenGameIsValid_ReturnOkResult(
            UpdateGameDTO updateGameDTO,
          [Frozen] Mock<IGameService> mockGameService,
          [NoAutoProperties] GamesController gamesController)
        {
            mockGameService.Setup(m => m.UpdateGameAsync(It.IsAny<UpdateGameDTO>())).ReturnsAsync(new GameDTO());

            var result = await gamesController.UpdateGameAsync(updateGameDTO);

            result.Should().BeOfType<OkObjectResult>();
        }

        [Theory, AutoDomainData]
        public void DownloadGameFile_GivenKey_ReturnFile([NoAutoProperties] GamesController gamesController)
        {
            var result = gamesController.DownloadGameFile("key");

            result.Should().BeOfType<PhysicalFileResult>();
        }
    }
}
