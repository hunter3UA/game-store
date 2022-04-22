using AutoFixture.Xunit2;
using FluentAssertions;
using GameStore.API.Controllers;
using GameStore.BLL.DTO;
using GameStore.BLL.Services.Abstract;
using GameStore.BLL.Services.Implementation;
using GameStore.DAL.UoW.Abstract;
using GameStore.Tests.Attributes;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GameStore.Tests.Controllers
{
    public class GameControllerTest
    {
        //[Theory,AutoDomainData]
        //public async Task AddGameAsync_IfGameAdded_ShouldReturnOkResult(AddGameDTO addGameDTO,[Frozen] Mock<IUnitOfWork> unitOfWork,
        //[Frozen] Mock<IGameService> gameService)
        //{
           
        //    GamesController gameController = new GamesController(gameService.Object);
        //    var result = await gameController.AddGameAsync(addGameDTO);

        //    result.Should().BeOfType<ActionResult<GenreDTO>>();
                
        //}
    }
}
