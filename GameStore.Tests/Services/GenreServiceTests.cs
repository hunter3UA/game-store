using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using AutoMapper;
using FluentAssertions;
using GameStore.BLL.DTO.Genre;
using GameStore.BLL.Services.Implementation;
using GameStore.DAL.Entities;
using GameStore.DAL.UoW.Abstract;
using GameStore.Tests.Attributes;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace GameStore.Tests.Services
{
    public class GenreServiceTests
    {
        [Theory, AutoDomainData]
        public async Task AddGenreAsync_GivenValidGenreToBeAdded_ReturnGenre(
            AddGenreDTO addGenreDTO,
            [Frozen] Mock<IUnitOfWork> mockUnitOfWork,
            IMapper mapper,
            GenreService genreService)
        {
            Genre genreToAdd = mapper.Map<Genre>(addGenreDTO);
            var id = 5;
            mockUnitOfWork.Setup(m => m.GenreRepository.AddAsync(It.IsAny<Genre>()))
                .ReturnsAsync(() =>
                {
                    genreToAdd.Id = id;
                    return genreToAdd;
                });

            var result = await genreService.AddGenreAsync(addGenreDTO);

            result.Should().BeOfType<GenreDTO>()
                .Which.Id.Should().Be(id);
        }

        [Theory, AutoDomainData]
        public async Task AddGenreAsync_GivenNull_ReturnDbUpdateException(
            [Frozen] Mock<IUnitOfWork> mockUnitOfWork,
            GenreService genreService)
        {
            mockUnitOfWork.Setup(m => m.GenreRepository.AddAsync(It.IsAny<Genre>())).ThrowsAsync(new DbUpdateException());

            Exception result = await Record.ExceptionAsync(() => genreService.AddGenreAsync(new AddGenreDTO()));

            result.Should().BeOfType<DbUpdateException>();
        }

        [Theory, AutoDomainData]
        public async Task GetGenreAsync_RequestedGenreExist_ReturnGenre(
           Genre genre,
           [Frozen] Mock<IUnitOfWork> mockUnitOfWork,
           GenreService genreService)
        {
            mockUnitOfWork.Setup(m => m.GenreRepository.GetAsync(It.IsAny<Expression<Func<Genre, bool>>>())).ReturnsAsync(genre);

            var result = await genreService.GetGenreAsync(genre.Id);

            result.Should().BeOfType<GenreDTO>().And.NotBeNull();
        }

        [Theory, AutoDomainData]
        public async Task GetGenreAsync_RequestedGenreNotExist_ThrowKeyNotFoundException(
           [Frozen] Mock<IUnitOfWork> mockUnitOfWork,
           GenreService genreService)
        {
            mockUnitOfWork.Setup(m => m.GenreRepository.GetAsync(
                It.IsAny<Expression<Func<Genre, bool>>>(),
                It.IsAny<Expression<Func<Genre, object>>[]>())).ReturnsAsync(() => { return null; });

            Exception result = await Record.ExceptionAsync(() => genreService.GetGenreAsync(-1));

            result.Should().BeOfType<KeyNotFoundException>();
        }

        [Theory, AutoDomainData]
        public async Task GetListOfGenresAsync_RequestedListExist_ReturnListOfGenres(
           [Frozen] Mock<IUnitOfWork> mockUnitOfWOrk,
           GenreService genreService)
        {
            mockUnitOfWOrk.Setup(m => m.GenreRepository.GetListAsync())
                .ReturnsAsync(new List<Genre>());
            var result = await genreService.GetListOfGenresAsync();
            result.Should().BeOfType(typeof(List<GenreDTO>));
        }

        [Theory, AutoDomainData]
        public async Task RemoveGenreAsync_GenreIsRemoved_ReturnTrue(
           Genre genre,
           [Frozen] Mock<IUnitOfWork> mockUnitOfWork,
           GenreService genreService)
        {
            mockUnitOfWork.Setup(m => m.GenreRepository.RemoveAsync(It.IsAny<Expression<Func<Genre, bool>>>())).ReturnsAsync(true);

            var isDeletedGenre = await genreService.RemoveGenreAsync(genre.Id);

            isDeletedGenre.Should().BeTrue();
        }

        [Theory, AutoDomainData]
        public async Task RemoveGenreAsync_GenreNotRemoved_ThrowArgumentException(
            [Frozen] Mock<IUnitOfWork> mockUnitOfWork, GenreService genreService)
        {
            mockUnitOfWork.Setup(m => m.GenreRepository.RemoveAsync(It.IsAny<Expression<Func<Genre, bool>>>())).ReturnsAsync(false);

            Exception result = await Record.ExceptionAsync(() => genreService.RemoveGenreAsync(1));

            result.Should().BeOfType<ArgumentException>();
        }

        [Theory, AutoDomainData]
        public async Task UpdateGenreAsync_GivenValidGenre_ReturnGenre(UpdateGenreDTO updateGenreDTO, [Frozen] Mock<IUnitOfWork> mockUnitOfWork, GenreService genreService)
        {
            mockUnitOfWork.Setup(m => m.GenreRepository.UpdateAsync(
               It.IsAny<Genre>(),
               It.IsAny<Expression<Func<Genre, object>>[]>())).ReturnsAsync(() => { return new Genre { Name = updateGenreDTO.Name }; });

            var result = await genreService.UpdateGenreAsync(updateGenreDTO);

            result.Name.Should().BeEquivalentTo(updateGenreDTO.Name);
        }

        [Theory, AutoDomainData]
        public async Task UpdateGenreAsync_GivenInvalidGenre_ReturnArgumentException(UpdateGenreDTO updateGenreDTO, [Frozen] Mock<IUnitOfWork> mockUnitOfWork, GenreService genreService)
        {
            updateGenreDTO.Id = 10;
            mockUnitOfWork.Setup(m => m.GenreRepository.UpdateAsync(
               It.IsAny<Genre>(),
               It.IsAny<Expression<Func<Genre, object>>[]>())).ReturnsAsync(() => { return null; });

            Exception result = await Record.ExceptionAsync(() => genreService.UpdateGenreAsync(null));

            result.Should().BeOfType<ArgumentException>();
        }
    }
}