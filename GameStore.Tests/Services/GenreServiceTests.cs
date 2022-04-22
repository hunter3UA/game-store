using AutoFixture.Xunit2;
using AutoMapper;
using FluentAssertions;
using GameStore.BLL.DTO;
using GameStore.BLL.Services.Implementation;
using GameStore.DAL.Entities;
using GameStore.DAL.UoW.Abstract;
using GameStore.Tests.Attributes;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GameStore.Tests.Services
{
    public class GenreServiceTests
    {
        [Theory, AutoDomainData]
        public async Task AddGenreAsync_GivenValidGenreToBeAdded_ReturnGenreDTO(AddGenreDTO addGenreDTO,
            [Frozen] Mock<IUnitOfWork> mockUnitOfWork,IMapper mapper, GenreService genreService
            )
        {
            Genre genreToAdd = mapper.Map<Genre>(addGenreDTO);
            var id = 5;
            mockUnitOfWork.Setup(m=>m.GenreRepository.AddGenreAsync(It.IsAny<Genre>()))
                .ReturnsAsync(() =>
                {
                    genreToAdd.Id = id;
                    return genreToAdd;
                });

            var result = await genreService.AddGenreAsync(addGenreDTO); 

            result.Should().BeOfType<GenreDTO>()
                .Which.Id.Should().Be(id);
        }

        [Theory,AutoDomainData]
        public async Task AddGenreAsync_GivenNull_ReturnException(
            [Frozen]Mock<IUnitOfWork> mockUnitOfWork,GenreService genreService)
        {
            mockUnitOfWork.Setup(m => m.GenreRepository.AddGenreAsync(It.IsAny<Genre>())).
                ReturnsAsync(()=> { return null; });
            var result = await genreService.AddGenreAsync(null);

            Assert.Null(result);
        }


        [Theory,AutoDomainData]
        public async Task GetGenreAsync_RequestedGenreExist_ReturnGenre(
           Genre genre, [Frozen]Mock<IUnitOfWork> mockUnitOfWork,GenreService genreService )
        {
            mockUnitOfWork.Setup(m=>m.GenreRepository.GetGenreAsync(It.IsAny<Expression<Func<Genre,bool>>>()))
                .ReturnsAsync(genre);
            var result = await genreService.GetGenreAsync(g => g.Id == genre.Id);
            result.Should().BeOfType<GenreDTO>().And.NotBeNull();
        }

        [Theory,AutoDomainData]
        public async Task GetListOfGenresAsync_RequestedListNotNull_ShouldReturnListOfGenres(
           [Frozen]Mock<IUnitOfWork> mockUnitOfWOrk, GenreService genreService)
        {
            mockUnitOfWOrk.Setup(m => m.GenreRepository.GetListOfGenresAsync())
                .ReturnsAsync(new List<Genre>());
            var result = await genreService.GetListOfGenresAsync();
            result.Should().BeOfType(typeof(List<GenreDTO>));
        }

        [Theory,AutoDomainData]
        public async Task RemoveGenreAsync_GenreIsRemoved_ReturnTrue(
           Genre genre, [Frozen] Mock<IUnitOfWork> mockUnitOfWork, GenreService genreService)
        {
            mockUnitOfWork.Setup(m => m.GenreRepository.RemoveGenreAsync(It.IsAny<int>())).ReturnsAsync(true);

            var isDeletedGenre = await genreService.RemoveGenreAsync(genre.Id);

            Assert.True(isDeletedGenre);
        }
        [Theory,AutoDomainData]
        public async Task RemoveGenreAsync_GenReNotRemoved_ShouldReturnFalse(
            [Frozen]Mock<IUnitOfWork> mockUnitOfWork, GenreService genreService
            )
        {
            mockUnitOfWork.Setup(m => m.GenreRepository.RemoveGenreAsync(It.IsAny<int>())).ReturnsAsync(false);

            var result = await genreService.RemoveGenreAsync(4);
            Assert.False(result);
        }
    }
}
