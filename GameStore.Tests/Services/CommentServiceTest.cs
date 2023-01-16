using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using AutoMapper;
using FluentAssertions;
using GameStore.BLL.DTO.Comment;
using GameStore.BLL.Services.Implementation;
using GameStore.DAL.Entities;
using GameStore.DAL.Entities.Games;
using GameStore.DAL.UoW.Abstract;
using GameStore.Tests.Attributes;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace GameStore.Tests.Services
{
    public class CommentServiceTest
    {
        [Theory, AutoDomainData]
        public async Task AddCommentAsync_GivenValiedComment_ReturnComment(
            AddCommentDTO addCommentDTO,
           [Frozen] Mock<IUnitOfWork> mockUnitOfWork,
           IMapper mapper,
           CommentService commentService)
        {
            Comment comment = mapper.Map<Comment>(addCommentDTO);
            var id = 10;
            mockUnitOfWork.Setup(m => m.CommentRepository.AddAsync(It.IsAny<Comment>()))
                .ReturnsAsync(() =>
                {
                    comment.Id = id;
                    return comment;
                });

            var result = await commentService.AddCommentAsync("Test key", addCommentDTO);

            result.Should().BeOfType<CommentDTO>().Which
                .Id.Should().Be(id);
        }

        [Theory, AutoDomainData]
        public async Task AddCommentAsync_GivenNull_ThrowException(
            Game game,
            [Frozen] Mock<IUnitOfWork> mockUnitOfWork,
            CommentService commentService)
        {
            AddCommentDTO commentToAddDTO = null;
            mockUnitOfWork.Setup(m => m.CommentRepository.AddAsync(It.IsAny<Comment>())).ReturnsAsync(() => new Comment());

            Exception shouldBeNotNull = await Record.ExceptionAsync(() => commentService.AddCommentAsync(game.Key, commentToAddDTO));

            shouldBeNotNull.Should().NotBeNull();
        }

        [Theory, AutoDomainData]
        public async Task GetCommentsAsync_ReqestedCommentExsit_ReturnComment(
            Comment comment, Game game, [Frozen] Mock<IUnitOfWork> mockUnitOfWork, CommentService commentServie)
        {
            mockUnitOfWork.Setup(m => m.CommentRepository.GetAsync(
                It.IsAny<Expression<Func<Comment, bool>>>())).ReturnsAsync(comment);

            var result = await commentServie.GetListOfCommentsAsync(game.Key);

            result.Should().BeOfType<List<CommentDTO>>().And.NotBeNull();
        }

        [Theory, AutoDomainData]
        public async Task RemoveCommentAsync_CommentIsNotRemoved_ReturnArgumentException(
           [Frozen] Mock<IUnitOfWork> mockUnitOfWork, CommentService commentService)
        {
            mockUnitOfWork.Setup(m => m.CommentRepository.RemoveAsync(It.IsAny<Expression<Func<Comment, bool>>>())).ReturnsAsync(false);

            Exception result = await Record.ExceptionAsync(() => commentService.RemoveCommentAsync(4));
            

            result.Should().BeOfType<ArgumentException>();
        }

        [Theory, AutoDomainData]
        public async Task RemoveCommentAsync_CommentRemoved_ReturnTrue(
           Comment commentToBeRemoved, [Frozen] Mock<IUnitOfWork> mockUnitOfWork, CommentService commentService)
        {
            mockUnitOfWork.Setup(m => m.CommentRepository.RemoveAsync(It.IsAny<Expression<Func<Comment, bool>>>())).ReturnsAsync(true);

            var result = await commentService.RemoveCommentAsync(commentToBeRemoved.Id);

            result.Should().BeTrue();
        }

        [Theory,AutoDomainData]
        public async Task UpdateCommentAsync_CommentIsUpdated_ReturnComment([Frozen] Mock<IUnitOfWork> mockUnitOfWork, CommentService commentService)
        {
            mockUnitOfWork.Setup(m => m.CommentRepository.GetAsync(
                It.IsAny<Expression<Func<Comment, bool>>>())).ReturnsAsync(new Comment());
            mockUnitOfWork.Setup(m => m.CommentRepository.UpdateAsync(It.IsAny<Comment>(),
                It.IsAny<Expression<Func<Comment, object>>[]>())).ReturnsAsync(new Comment());

            var result = await commentService.UpdateCommentAsync(new UpdateCommentDTO());

            result.Should().BeOfType<CommentDTO>();
        }

        [Theory, AutoDomainData]
        public async Task UpdateCommentAsync_CommentNotUpdated_ThrowArgumentException([Frozen] Mock<IUnitOfWork> mockUnitOfWork, CommentService commentService)
        {
            mockUnitOfWork.Setup(m => m.CommentRepository.UpdateAsync(It.IsAny<Comment>(),
                It.IsAny<Expression<Func<Comment, object>>[]>())).ReturnsAsync(()=> { return null; });

            Exception result = await Record.ExceptionAsync(() => commentService.UpdateCommentAsync(new UpdateCommentDTO()));

            result.Should().BeOfType<ArgumentException>();
        }

        [Theory, AutoDomainData]
        public async Task UpdateCommentAsync_CommentNotExist_ThrowKeyNotFoundException([Frozen] Mock<IUnitOfWork> mockUnitOfWork, CommentService commentService)
        {

            mockUnitOfWork.Setup(m => m.CommentRepository.GetAsync(
                It.IsAny<Expression<Func<Comment, bool>>>())).ReturnsAsync(()=> { return null; });

            mockUnitOfWork.Setup(m => m.CommentRepository.UpdateAsync(It.IsAny<Comment>(),
                It.IsAny<Expression<Func<Comment, object>>[]>())).ThrowsAsync(new DbUpdateException());

            Exception result = await Record.ExceptionAsync(() => commentService.UpdateCommentAsync(new UpdateCommentDTO()));

            result.Should().BeOfType<KeyNotFoundException>();
        }
    }
}