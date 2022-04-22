using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Community.AutoMapper;
using AutoFixture.Xunit2;
using AutoMapper;
using FluentAssertions;
using GameStore.BLL.DTO;
using GameStore.BLL.Mapper;
using GameStore.BLL.Services.Implementation;
using GameStore.DAL.Entities;
using GameStore.DAL.Repositories.Abstract;
using GameStore.DAL.UoW.Abstract;
using GameStore.Tests.Attributes;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GameStore.Tests.Services
{
    public class GameServiceTests
    {
        [Theory, AutoDomainData]
        public async Task AddGameAsync_GivenValidGameToBeAdded_ReturnGame(
             AddGameDTO gameToAddDto, [Frozen] Mock<IUnitOfWork> mockUnitOfWork, IMapper mapper, GameService gameService)
        {
            Game gameToAdd = mapper.Map<Game>(gameToAddDto);
            var id = 15;
            mockUnitOfWork.Setup(m => m.GameRepository.AddGameAsync(It.IsAny<Game>())).ReturnsAsync(
                () =>
                {
                    gameToAdd.Id = id;
                    return gameToAdd;
                });

            var result = await gameService.AddGameAsync(gameToAddDto);

            result.Should().NotBeNull().And.BeOfType<GameDTO>().Which.
                Id.Should().Be(id);
        }

        [Theory, AutoDomainData]
        public async Task AddGameAsync_GivenNull_ThrowException(
            [Frozen] Mock<IUnitOfWork> mockUnitOfWork, IMapper mapper, GameService gameService)
        {
            AddGameDTO gameToAddDTO = null;
            mockUnitOfWork.Setup(m => m.GameRepository.AddGameAsync(It.IsAny<Game>())).ReturnsAsync(new Game());

            Exception shouldBeNotNull = await Record.ExceptionAsync(() => gameService.AddGameAsync(gameToAddDTO));

            Assert.NotNull(shouldBeNotNull);
        }

        [Theory, AutoDomainData]
        public async Task GetListOfGamesAsync_ListExist_ReturnListOfGames(
            [Frozen] Mock<IUnitOfWork> mockUnitOfWork, IMapper mapper, GameService gameService)
        {
            mockUnitOfWork.Setup(m => m.GameRepository.GetListOfGamesAsync());

            var listOfGames = await gameService.GetListOfGamesAsync();

            Assert.NotNull(listOfGames);
        }

        [Theory, AutoDomainData]
        public async Task GetGameAsync_GivenValidKey_ReturnGame(
            string Key, Game game, [Frozen] Mock<IUnitOfWork> mockUnitOfWork, IMapper mapper, GameService gameService)
        {
            game.Key = Key;
            mockUnitOfWork.Setup(m => m.GameRepository.GetGameAsync(
                It.IsAny<Expression<Func<Game, bool>>>()
                )).ReturnsAsync(game);

            var actualGame = await gameService.GetGameAsync(g => g.Key == Key);

            Assert.Equal(Key, actualGame.Key);
        }

        [Theory, AutoDomainData]
        public async Task RemoveGameAsync_GivenValidKey_ReturnTrue(
            Game game, [Frozen] Mock<IUnitOfWork> mockUnitOfWork, IMapper mapper, GameService gameService)
        {
            mockUnitOfWork.Setup(m => m.GameRepository.RemoveGameAsync(It.IsAny<string>())).ReturnsAsync(true);

            var isDeletedGame = await gameService.RemoveGameAsync(game.Key);

            Assert.True(isDeletedGame);
        }

        [Theory, AutoDomainData]
        public async Task UpdateGameAsync_GivenValidGameToBeUpdated_ReturnGame(
            UpdateGameDTO updateGameDTO, Game existedGame, [Frozen] Mock<IUnitOfWork> mockUnitOfWork, GameService gameService)
        {
            mockUnitOfWork.Setup(m => m.GameRepository.UpdateGameAsync(It.IsAny<Game>())).ReturnsAsync(existedGame);

            var result = await gameService.UpdateGameAsync(updateGameDTO);

            Assert.Equal(updateGameDTO.Name, result.Name);
        }
    }
}
