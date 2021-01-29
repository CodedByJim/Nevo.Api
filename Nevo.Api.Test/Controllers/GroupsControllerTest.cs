using System.Threading;
using Coded.Core.Handler;
using Coded.Core.Testing;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Nevo.Api.Controllers;
using Nevo.Contract.V1.Groups;
using Nevo.Test.Shared;
using Xunit;

namespace Nevo.Api.Test.Controllers
{
    public class GroupsControllerTest
    {
        private readonly GroupsController _controller;
        private readonly Mock<IHandler<GetGroupRequest, GetGroupResponse>> _getGroupHandler;
        private readonly Mock<IHandler<GetGroupProductsRequest, GetGroupProductsResponse>> _getGroupProductsHandler;
        private readonly Mock<IHandler<GetGroupsRequest, GetGroupsResponse>> _getGroupsHandler;

        public GroupsControllerTest()
        {
            _getGroupsHandler = new();
            _getGroupHandler = new();
            _getGroupProductsHandler = new();
            _controller = new(_getGroupsHandler.Object, _getGroupHandler.Object, _getGroupProductsHandler.Object);
        }

        [Fact(DisplayName = "If there are groups, get returns them.")]
        public async void GetGroups_ReturnsGroups()
        {
            // Arrange
            GetGroupsResponse response = new()
            {
                Groups = new()
                {
                    new()
                    {
                        Code = 1,
                        DescriptionEn = "Test group",
                        DescriptionNl = "Testgroep"
                    }
                }
            };
            _getGroupsHandler.SetupHandle(_ => response);

            // Act
            var output = await _controller.GetGroups(CancellationToken.None);

            // Assert
            Assert.IsType<OkObjectResult>(output.Result);
            var okObjectResult = output.Result as OkObjectResult;
            Verify.NotNull(okObjectResult);
            Verify.NotNull(okObjectResult.Value);
            Assert.Equal(response, okObjectResult.Value);
        }

        [Fact(DisplayName = "If no groups exists, return not found.")]
        public async void GetGroups_ReturnsNotFound()
        {
            // Arrange
            _getGroupsHandler.SetupHandle(_ => null);

            // Act
            var output = await _controller.GetGroups(CancellationToken.None);

            // Assert
            Assert.IsType<NotFoundResult>(output.Result);
            Assert.Null(output.Value);
        }

        [Fact(DisplayName = "If the group exists, return it.")]
        public async void GetGroup_ReturnsGroup()
        {
            // Arrange

            GetGroupResponse response = new()
            {
                Group = new()
                {
                    Code = 1,
                    DescriptionEn = "En",
                    DescriptionNl = "Nl"
                }
            };
            _getGroupHandler.SetupHandle(_ => response);

            // Act
            var output = await _controller.GetGroup(
                new()
                {
                    GroupCode = 1
                },
                CancellationToken.None);

            // Assert
            Assert.IsType<OkObjectResult>(output.Result);
            var okResult = output.Result as OkObjectResult;
            Verify.NotNull(okResult);
            Verify.NotNull(okResult.Value);
            Assert.Equal(response, okResult.Value);
        }

        [Fact(DisplayName = "If the group doesnt exists, return not found.")]
        public async void GetGroup_ReturnsNotFound()
        {
            // Arrange
            _getGroupHandler.SetupHandle(_ => null);

            // Act
            var output = await _controller.GetGroup(
                new()
                {
                    GroupCode = 1
                },
                CancellationToken.None);

            // Assert
            Assert.IsType<NotFoundResult>(output.Result);
            Assert.Null(output.Value);
        }

        [Fact(DisplayName = "If the group products exists, return it.")]
        public async void GetGroupProducts_ReturnsGroupProducts()
        {
            // Arrange
            GetGroupProductsResponse response = new()
            {
                GroupCode = 1,
                Total = 1,
                Products = new()
                {
                    new()
                    {
                        Code = 1,
                        DescriptionEn = "En",
                        DescriptionNl = "Nl"
                    }
                }
            };

            _getGroupProductsHandler.SetupHandle(_ => response);

            // Act
            var output = await _controller.GetGroupProducts(
                new()
                {
                    GroupCode = 1
                },
                CancellationToken.None);

            // Assert
            Assert.IsType<OkObjectResult>(output.Result);
            var okResult = output.Result as OkObjectResult;
            Verify.NotNull(okResult);
            Verify.NotNull(okResult.Value);
            Assert.Equal(response, okResult.Value);
        }

        [Fact(DisplayName = "If no group products exists, return not found.")]
        public async void GetGroupProducts_ReturnsNotFound()
        {
            // Arrange
            _getGroupsHandler.SetupHandle(_ => null);

            // Act
            var output = await _controller.GetGroupProducts(new()
            {
                GroupCode = 1
            }, CancellationToken.None);

            // Assert
            Assert.IsType<NotFoundResult>(output.Result);
            Assert.Null(output.Value);
        }
    }
}