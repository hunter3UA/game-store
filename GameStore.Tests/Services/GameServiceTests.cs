using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using AutoMapper;
using FluentAssertions;
using GameStore.BLL.DTO;
using GameStore.BLL.Services.Implementation;
using GameStore.DAL.Entities;
using GameStore.DAL.UoW.Abstract;
using GameStore.Tests.Attributes;
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
            AddGameDTO gameToAddDTO = null;
            mockUnitOfWork.Setup(m => m.GameRepository.AddAsync(It.IsAny<Game>())).ReturnsAsync(new Game());

            Exception shouldBeNotNull = await Record.ExceptionAsync(() => gameService.AddGameAsync(gameToAddDTO));

            shouldBeNotNull.Should().NotBeNull();
        }

        [Theory, AutoDomainData]
        public async Task GetListOfGamesAsync_ListExist_ReturnListOfGames(
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

            var actualGame = await gameService.GetGameAsync(g => g.Key == key);

            Assert.Equal(key, actualGame.Key);
        }

        [Theory, AutoDomainData]
        public async Task RemoveGameAsync_GivenValidKey_ReturnTrue(
            Game game, 
            [Frozen] Mock<IUnitOfWork> mockUnitOfWork, 
            GameService gameService)
        {
            mockUnitOfWork.Setup(m => m.GameRepository.RemoveAsync(It.IsAny<Expression<Func<Game, bool>>>())).ReturnsAsync(true);

            var isDeletedGame = await gameService.RemoveGameAsync(game.Key);

            isDeletedGame.Should().BeTrue();
        }

        [Theory, AutoDomainData]
        public async Task UpdateGameAsync_GivenValidGameToBeUpdated_ReturnGame(
            UpdateGameDTO updateGameDTO, 
            Game existedGame, 
            [Frozen] Mock<IUnitOfWork> mockUnitOfWork, 
            GameService gameService)
        {
            mockUnitOfWork.Setup(m => m.GameRepository.UpdateAsync(It.IsAny<Game>())).ReturnsAsync(existedGame);

            var result = await gameService.UpdateGameAsync(updateGameDTO);

            result.Name.Should().BeEquivalentTo(updateGameDTO.Name);
        }
    }
}
