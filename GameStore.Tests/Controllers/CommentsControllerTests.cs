using System.Collections.Generic;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using AutoMapper;
using FluentAssertions;
using GameStore.API.Controllers;
using GameStore.BLL.DTO.Comment;
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
        public async Task AddCommentAsync_GivenCommentIsValid_ReturnJsonResult(
            AddCommentDTO addCommentDTO,
            IMapper mapper,
        [Frozen] Mock<ICommentService> mockCommentService,
        [NoAutoProperties] CommentsController commentsController)
        {
            Comment commentToAdd = mapper.Map<Comment>(addCommentDTO);
            mockCommentService.Setup(m => m.AddCommentAsync(It.IsAny<string>(), It.IsAny<AddCommentDTO>()))
                .ReturnsAsync(() => { return mapper.Map<CommentDTO>(commentToAdd); });

            var result = await commentsController.AddCommentAsync("myKey", addCommentDTO);

            result.Should().BeOfType<JsonResult>();
        }

        [Theory, AutoDomainData]
        public async Task GetCommentAsync_RequestedCommentExist_ReturnJsonResult(
             List<Comment> comments,
            [Frozen] Mock<ICommentService> mockCommentService,
            IMapper mapper,
            [NoAutoProperties] CommentsController commentsController)
        {
            mockCommentService.Setup(m => m.GetListOfCommentsAsync(It.IsAny<string>()))
                .ReturnsAsync(() =>
                {
                    return mapper.Map<List<CommentDTO>>(comments);
                });

            var result = await commentsController.GetCommentsAsync("gameKey");

            result.Should().BeOfType<JsonResult>();
        }

    }
}
