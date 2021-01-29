using System.Threading;
using Coded.Core.Handler;
using Coded.Core.Testing;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Nevo.Api.Controllers;
using Nevo.Contract.V1.Nutrients;
using Nevo.Test.Shared;
using Xunit;

namespace Nevo.Api.Test.Controllers
{
    public class NutrientControllerTest
    {
        private readonly NutrientsController _controller;
        private readonly Mock<IHandler<GetNutrientRequest, GetNutrientResponse>> _getNutrientHandler;
        private readonly Mock<IHandler<GetNutrientProductsRequest, GetNutrientProductsResponse>> _getNutrientProductsHandler;
        private readonly Mock<IHandler<GetNutrientsRequest, GetNutrientsResponse>> _getNutrientsHandler;

        public NutrientControllerTest()
        {
            _getNutrientHandler = new();
            _getNutrientsHandler = new();
            _getNutrientProductsHandler = new();
            _controller = new(_getNutrientsHandler.Object, _getNutrientHandler.Object, _getNutrientProductsHandler.Object);
        }

        [Fact(DisplayName = "If there are nutrients, return them.")]
        public async void GetNutrients_ReturnsNutrients()
        {
            // Arrange
            GetNutrientsResponse response = new()
            {
                Nutrients = new()
                {
                    new()
                    {
                        Code = "NUT",
                        NameEn = "En",
                        NameNl = "Nl"
                    }
                }
            };

            _getNutrientsHandler.SetupHandle(_ => response);

            // Act
            var output = await _controller.GetNutrients(CancellationToken.None);

            // Assert
            Assert.IsType<OkObjectResult>(output.Result);
            var okObjectResult = output.Result as OkObjectResult;
            Verify.NotNull(okObjectResult);
            Verify.NotNull(okObjectResult.Value);
            Assert.Equal(response, okObjectResult.Value);
        }

        [Fact(DisplayName = "If no nutrients exists, return not found.")]
        public async void GetNutrients_ReturnsNotFound()
        {
            // Arrange
            _getNutrientsHandler.SetupHandle(_ => null);

            // Act
            var output = await _controller.GetNutrients(CancellationToken.None);

            // Assert
            Assert.IsType<NotFoundResult>(output.Result);
            Assert.Null(output.Value);
        }

        [Fact(DisplayName = "If the nutrient exists, return it.")]
        public async void GetNutrient_ReturnsNutrient()
        {
            // Arrange
            GetNutrientResponse response = new()
            {
                Nutrient = new()
                {
                    Code = "NUT",
                    NameEn = "En",
                    NameNl = "Nl"
                }
            };
            _getNutrientHandler.SetupHandle(_ => response);

            // Act
            var output = await _controller.GetNutrient(
                new()
                {
                    NutrientCode = "NUT"
                },
                CancellationToken.None);

            // Assert
            Assert.IsType<OkObjectResult>(output.Result);
            var okResult = output.Result as OkObjectResult;
            Verify.NotNull(okResult);
            Verify.NotNull(okResult.Value);
            Assert.Equal(response, okResult.Value);
        }

        [Fact(DisplayName = "If the nutrient doesnt exists, return not found.")]
        public async void GetNutrient_ReturnsNotFound()
        {
            // Arrange
            _getNutrientHandler.SetupHandle(_ => null);

            // Act
            var output = await _controller.GetNutrient(
                new()
                {
                    NutrientCode = "NUT"
                }, CancellationToken.None);

            // Assert
            Assert.IsType<NotFoundResult>(output.Result);
            Assert.Null(output.Value);
        }

        [Fact(DisplayName = "If the nutrient's products exists, return it.")]
        public async void GetNutrientProducts_ReturnsNutrientProducts()
        {
            // Arrange
            GetNutrientProductsResponse response = new()
            {
                Total = 1,
                Products = new()
                {
                    new()
                    {
                        Percentage = 5,
                        ProductCode = 1,
                        SourceId = "SourceId"
                    }
                }
            };

            _getNutrientProductsHandler.SetupHandle(_ => response);

            // Act
            var output = await _controller.GetNutrientProducts(
                new()
                {
                    NutrientCode = "NUT"
                },
                CancellationToken.None);

            // Assert
            Assert.IsType<OkObjectResult>(output.Result);
            var okResult = output.Result as OkObjectResult;
            Verify.NotNull(okResult);
            Verify.NotNull(okResult.Value);
            Assert.Equal(response, okResult.Value);
        }

        [Fact(DisplayName = "If no nutrient products exists, return not found.")]
        public async void GetNutrientProducts_ReturnsNotFound()
        {
            // Arrange
            _getNutrientProductsHandler.SetupHandle(_ => null);

            // Act
            var output = await _controller.GetNutrientProducts(new()
            {
                NutrientCode = "NUT"
            }, CancellationToken.None);

            // Assert
            Assert.IsType<NotFoundResult>(output.Result);
            Assert.Null(output.Value);
        }
    }
}