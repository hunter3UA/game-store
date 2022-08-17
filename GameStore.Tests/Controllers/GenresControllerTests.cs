using System.Collections.Generic;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using AutoMapper;
using FluentAssertions;
using GameStore.API.Controllers;
using GameStore.BLL.DTO.Genre;
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
        public async Task AddGenreAsync_GivenGenreIsValid_ReturnJsonResult(
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

            var result = await genresController.AddAsync(addGenreDTO);

            result.Should().BeOfType<JsonResult>();
        }

        [Theory, AutoDomainData]
        public async Task GetListOfGenresAsync_RequestedGenreExist_ReturnJsonResult(
            [Frozen] Mock<IGenreService> mockGenreService,
            [NoAutoProperties] GenresController genresController)
        {
            mockGenreService.Setup(m => m.GetListOfGenresAsync()).ReturnsAsync(new List<GenreDTO>());

            var result = await genresController.GetListAsync();

            result.Should().BeOfType<JsonResult>();
        }



        [Theory, AutoDomainData]
        public async Task GetGenreAsync_RequestedGenreExist_ReturnJsonResult(
            Genre genre, 
            IMapper mapper,
            [Frozen] Mock<IGenreService> mockGenreService,
            [NoAutoProperties] GenresController genresController)
        {
            mockGenreService.Setup(m => m.GetGenreAsync(It.IsAny<int>()))
                .ReturnsAsync(() => { return mapper.Map<GenreDTO>(genre); });
            var result = await genresController.GetAsync(genre.Id);

            result.Should().BeOfType<JsonResult>();
        }

        [Theory, AutoDomainData]
        public async Task RemoveGenreAsync_RequestedGenreRemoved_ReturnOkResult(
            int id,
            [Frozen] Mock<IGenreService> mockGenreService,
            [NoAutoProperties] GenresController genresController)
        {
            mockGenreService.Setup(m => m.RemoveGenreAsync(It.IsAny<int>())).ReturnsAsync(true);

            var result = await genresController.RemoveAsync(id);

            result.Should().BeOfType<OkResult>();
        }

        [Theory,AutoDomainData]
        public async Task UpdateGenreAsync_GivenGenreIsValid_ReturnJsonResult(UpdateGenreDTO updateGenreDTO, [Frozen] Mock<IGenreService> mockGenreService,
            [NoAutoProperties] GenresController genresController)
        {
            mockGenreService.Setup(m => m.UpdateGenreAsync(It.IsAny<UpdateGenreDTO>())).ReturnsAsync(()=> {
                return new GenreDTO();
            });

            var result = await genresController.UpdateAsync(updateGenreDTO);

            result.Should().BeOfType<JsonResult>();
        }

    }
}
