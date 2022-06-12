using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using AutoMapper;
using FluentAssertions;
using GameStore.BLL.DTO.Common;
using GameStore.BLL.DTO.Game;
using GameStore.BLL.Services.Implementation.Games;
using GameStore.DAL.Entities;
using GameStore.DAL.UoW.Abstract;
using GameStore.Tests.Attributes;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace GameStore.Tests.Services
{
    public class GameServiceTests
    {
        [Theory, AutoDomainData]
        public async Task AddGameAsync_GivenValidGameToBeAdded_ReturnGame(
             AddGameDTO gameToAddDto,
             [Frozen] Mock<IUnitOfWork> mockUnitOfWork,
             IMapper mapper,
             GameService gameService)
        {
            Game gameToAdd = mapper.Map<Game>(gameToAddDto);
            var id = 15;
            mockUnitOfWork.Setup(m => m.GameRepository.AddAsync(It.IsAny<Game>())).ReturnsAsync(
                () =>
                {
                    gameToAdd.Id = id;
                    return gameToAdd;
                });

            var result = await gameService.AddGameAsync(gameToAddDto);

            result.Should().NotBeNull().And.BeOfType<GameDTO>().Which.Id.Should().Be(id);
        }

        [Theory, AutoDomainData]
        public async Task AddGameAsync_GivenNull_ThrowException(
            [Frozen] Mock<IUnitOfWork> mockUnitOfWork,
            GameService gameService)
        {

            mockUnitOfWork.Setup(m => m.GameRepository.AddAsync(It.IsAny<Game>())).ThrowsAsync(new DbUpdateException());

            Exception shouldBeNotNull = await Record.ExceptionAsync(() => gameService.AddGameAsync(new AddGameDTO()));

            shouldBeNotNull.Should().BeOfType<DbUpdateException>();
        }


        [Theory, AutoDomainData]
        public async Task GetRangeOfGamesAsync_GivenValidFilter_ReturnListOfGames([Frozen] Mock<IUnitOfWork> mockUnitOfWork,List<Game> testList, GameService gameService)
        {
            mockUnitOfWork.Setup(m => m.GameRepository.CountListAsync(It.IsAny<List<Expression<Func<Game, bool>>>>())).ReturnsAsync(3);

            var result = await gameService.GetRangeOfGamesAsync(new GameFilterDTO { ElementsOnPage = 10 });

            result.Should().BeOfType<ItemPageDTO<GameDTO>>();
            result.PageInfo.TotalPages.Should().Be(1);
        }

        [Theory, AutoDomainData]
        public async Task GetCountAsync_RequestedListExist_ReturnNumberOfElements([Frozen] Mock<IUnitOfWork> mockUnitOfWork, GameService gameService)
        {
            mockUnitOfWork.Setup(m => m.GameRepository.CountListAsync(It.IsAny<List<Expression<Func<Game, bool>>>>())).ReturnsAsync(3);

            var result = await gameService.GetCountAsync();

            result.Should().Be(3);
        }

        [Theory, AutoDomainData]
        public async Task GetListOfGamesAsync_RequestListExist_ReturnListOfGames(
            [Frozen] Mock<IUnitOfWork> mockUnitOfWork,
            GameService gameService)
        {
            mockUnitOfWork.Setup(m => m.GameRepository.GetListAsync());

            var listOfGames = await gameService.GetListOfGamesAsync();

            listOfGames.Should().NotBeNull();
        }

        [Theory, AutoDomainData]
        public async Task GetGameAsync_GivenValidKey_ReturnGame(
             string key,
             Game game,
             [Frozen] Mock<IUnitOfWork> mockUnitOfWork,
             GameService gameService)
        {
            game.Key = key;
            mockUnitOfWork.Setup(m => m.GameRepository.GetAsync(
                It.IsAny<Expression<Func<Game, bool>>>(),
                It.IsAny<Expression<Func<Game, object>>[]>())).ReturnsAsync(game);

            var actualGame = await gameService.GetGameAsync(key, false);

            Assert.Equal(key, actualGame.Key);
        }

        [Theory, AutoDomainData]
        public async Task GetGameAsync_GivenInvalidKey_ReturnKeyNotFoundException(
            [Frozen] Mock<IUnitOfWork> mockUnitOfWork,
             GameService gameService)
        {
            mockUnitOfWork.Setup(m => m.GameRepository.GetAsync(
                It.IsAny<Expression<Func<Game, bool>>>(),
                It.IsAny<Expression<Func<Game, object>>[]>())).ReturnsAsync(() => { return null; });

            Exception result = await Record.ExceptionAsync(() => gameService.GetGameAsync("key", false));

            result.Should().BeOfType<KeyNotFoundException>();
        }

        [Theory, AutoDomainData]
        public async Task RemoveGameAsync_GivenValidKey_ReturnTrue(
            Game game,
            [Frozen] Mock<IUnitOfWork> mockUnitOfWork,
            GameService gameService)
        {
            mockUnitOfWork.Setup(m => m.GameRepository.RemoveAsync(It.IsAny<Expression<Func<Game, bool>>>())).ReturnsAsync(true);

            var isDeletedGame = await gameService.RemoveGameAsync(game.Id);

            isDeletedGame.Should().BeTrue();
        }

        [Theory, AutoDomainData]
        public async Task RemoveGameAsync_GivenInvalidKey_ThrowArgumentException(
            [Frozen] Mock<IUnitOfWork> mockUnitOfWork,
            GameService gameService)
        {
            mockUnitOfWork.Setup(m => m.GameRepository.RemoveAsync(It.IsAny<Expression<Func<Game, bool>>>())).ReturnsAsync(false);

            Exception result = await Record.ExceptionAsync(() => gameService.RemoveGameAsync(1));

            result.Should().BeOfType<ArgumentException>();
        }

        [Theory, AutoDomainData]
        public async Task UpdateGameAsync_GivenValidGameToBeUpdated_ReturnGame(
            UpdateGameDTO updateGameDTO,
            [Frozen] Mock<IUnitOfWork> mockUnitOfWork,
            GameService gameService)
        {
            mockUnitOfWork.Setup(m => m.GameRepository.UpdateAsync(
                It.IsAny<Game>(),
                It.IsAny<Expression<Func<Game, object>>[]>())).ReturnsAsync(() => { return new Game { Name = updateGameDTO.Name }; });

            var result = await gameService.UpdateGameAsync(updateGameDTO);

            result.Name.Should().BeEquivalentTo(updateGameDTO.Name);
        }

        [Theory, AutoDomainData]
        public async Task UpdateGameAsync_GivenInValidGameToBeUpdated_ThrowArgumentException(
            [Frozen] Mock<IUnitOfWork> mockUnitOfWork,
            GameService gameService)
        {
            mockUnitOfWork.Setup(m => m.GameRepository.UpdateAsync(
                It.IsAny<Game>(),
                It.IsAny<Expression<Func<Game, object>>[]>())).ReturnsAsync(() => { return null; });

            var result = await Record.ExceptionAsync(() => gameService.UpdateGameAsync(new UpdateGameDTO()));

            result.Should().BeOfType<ArgumentException>();
        }
    }
}
