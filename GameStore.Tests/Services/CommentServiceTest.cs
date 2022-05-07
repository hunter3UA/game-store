using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using AutoMapper;
using FluentAssertions;
using GameStore.BLL.DTO;
using GameStore.BLL.DTO.Comment;
using GameStore.BLL.Services.Implementation;
using GameStore.DAL.Entities;
using GameStore.DAL.UoW.Abstract;
using GameStore.Tests.Attributes;
using Moq;
using Xunit;

namespace GameStore.Tests.Services
{
    public class CommentServiceTest
    {
        [Theory, AutoDomainData]
        public async Task AddCommentAsync_GivenValiedComment_ReturnComment(
            AddCommentDTO addCommentDTO,
            Game game,
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

            var result = await commentService.AddCommentAsync(game.Key, addCommentDTO);

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
        public async Task RemoveCommentAsync_CommentIsNotRemoved_ReturnFalse(
           [Frozen] Mock<IUnitOfWork> mockUnitOfWork, CommentService commentService)    
        {
            mockUnitOfWork.Setup(m => m.CommentRepository.RemoveAsync(It.IsAny<Expression<Func<Comment,bool>>>())).ReturnsAsync(false);

            var result = await commentService.RemoveCommentAsync(4);

            result.Should().BeFalse();
        }

        [Theory, AutoDomainData]
        public async Task RemoveCommentAsync_CommentRemoved_ReturnTrue(
           Comment commentToBeRemoved, [Frozen] Mock<IUnitOfWork> mockUnitOfWork, CommentService commentService)
        {
            mockUnitOfWork.Setup(m => m.CommentRepository.RemoveAsync(It.IsAny<Expression<Func<Comment, bool>>>())).ReturnsAsync(true);

            var result = await commentService.RemoveCommentAsync(commentToBeRemoved.Id);

            result.Should().BeTrue();
        }
    }
}