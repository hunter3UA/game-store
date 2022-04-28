using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
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
    public class GenresControllerTests
    {
        [Theory, AutoDomainData]
        public async Task AddGenreAsync_GivenGenreIsValid_ReturnGenre(
            IMapper mapper, 
            AddGenreDTO addGenreDTO,
            [Frozen] Mock<IGenreService> mockGenreService,
            [NoAutoProperties] GenresController genresController)
        {
            Genre genreToAdd = mapper.Map<Genre>(addGenreDTO);
            var id = 10;
            genreToAdd.Id = id;
            mockGenreService.Setup(m => m.AddGenreAsync(It.IsAny<AddGenreDTO>()))
                .ReturnsAsync(() =>
                {
                    genreToAdd.Id = id;
                    return mapper.Map<GenreDTO>(genreToAdd);
                });

            var result = await genresController.AddGenreAsync(addGenreDTO);

            result.Should().BeOfType<OkObjectResult>();
        }

        [Theory, AutoDomainData]
        public async Task GetListOfGenresAsync_RequestedGenreExist_ReturnOkResult(
            [Frozen] Mock<IGenreService> mockGenreService,
            [NoAutoProperties] GenresController genresController)
        {
            mockGenreService.Setup(m => m.GetListOfGenresAsync()).ReturnsAsync(new List<GenreDTO>());

            var result = await genresController.GetAllGenresAsync();

            result.Should().BeOfType<OkObjectResult>();
        }

        [Theory, AutoDomainData]
        public async Task GetGenreAsync_GenreNotExist_ReturnNotFoundResult(
            [Frozen] Mock<IGenreService> mockGenreService, 
            [NoAutoProperties] GenresController genresController)
        {
            mockGenreService.Setup(m => m.GetGenreAsync(It.IsAny<int>()))
                .ReturnsAsync(() => { return null; });

            var result = await genresController.GetGenreAsync(100);

            result.Should().BeOfType<NotFoundResult>();
        }

        [Theory, AutoDomainData]
        public async Task GetGenreAsync_GenreExist_ReturnOkResult(
            Genre genre, 
            IMapper mapper,
            [Frozen] Mock<IGenreService> mockGenreService,
            [NoAutoProperties] GenresController genresController)
        {
            mockGenreService.Setup(m => m.GetGenreAsync(It.IsAny<int>()))
                .ReturnsAsync(() => { return mapper.Map<GenreDTO>(genre); });
            var result = await genresController.GetGenreAsync(genre.Id);

            result.Should().BeOfType<OkObjectResult>();
        }

        [Theory, AutoDomainData]
        public async Task RemoveGenreAsync_GenreRemoved_ReturnOkResult(
            int id,
            [Frozen] Mock<IGenreService> mockGenreService,
            [NoAutoProperties] GenresController genresController)
        {
            mockGenreService.Setup(m => m.RemoveGenreAsync(It.IsAny<int>())).ReturnsAsync(true);

            var result = await genresController.RemoveGenreAsync(id);

            result.Should().BeOfType<OkObjectResult>();
        }
    }
}
