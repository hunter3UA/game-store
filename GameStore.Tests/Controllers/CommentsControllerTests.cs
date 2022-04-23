using System;
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
    public class CommentsControllerTests
    {
        [Theory, AutoDomainData]
        public async Task AddCommentAsync_GivenCommentIsValid_ReturnOkResult(
            AddCommentDTO addCommentDTO,
            IMapper mapper,
        [Frozen] Mock<ICommentService> mockCommentService,
        [NoAutoProperties] CommentsController commentsController)
        {
            Comment commentToAdd = mapper.Map<Comment>(addCommentDTO);
            mockCommentService.Setup(m => m.AddCommentAsync(It.IsAny<string>(), It.IsAny<AddCommentDTO>()))
                .ReturnsAsync(() => { return mapper.Map<CommentDTO>(commentToAdd); });

            var result = await commentsController.AddCommentAsync("myKey", addCommentDTO);

            result.Should().BeOfType<OkObjectResult>();
        }

        [Theory, AutoDomainData]
        public async Task GetCommentAsync_CommentExist_ReturnOkResult(
            Comment comment,
            [Frozen] Mock<ICommentService> mockCommentService,
            IMapper mapper,
            [NoAutoProperties] CommentsController commentsController)
        {
            mockCommentService.Setup(m => m.GetCommentAsync(It.IsAny<Expression<Func<Comment, bool>>>()))
                .ReturnsAsync(() =>
                {
                    return mapper.Map<CommentDTO>(comment);
                });

            var result = await commentsController.GetCommentAsync("gameKey");

            result.Should().BeOfType<OkObjectResult>();
        }

        [Theory, AutoDomainData]
        public async Task RemoveCommentAsync_CommentRemoved_ReturnOkResult(
            [Frozen] Mock<ICommentService> mockCommentService, [NoAutoProperties] CommentsController commentsController)
        {
            mockCommentService.Setup(m => m.RemoveCommentAsync(It.IsAny<int>())).ReturnsAsync(true);

            var result = await commentsController.RemoveCommentAsync(10);

            result.Should().BeOfType<OkObjectResult>();
        }
    }
}
