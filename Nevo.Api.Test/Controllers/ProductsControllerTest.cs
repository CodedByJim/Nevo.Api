using System.Threading;
using Coded.Core.Handler;
using Coded.Core.Testing;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Nevo.Api.Controllers;
using Nevo.Contract.V1.Products;
using Nevo.Test.Shared;
using Xunit;

namespace Nevo.Api.Test.Controllers
{
    public class ProductsControllerTest
    {
        private readonly ProductsController _controller;
        private readonly Mock<IHandler<GetProductRequest, GetProductResponse>> _getProductHandler;
        private readonly Mock<IHandler<GetProductNutrientsRequest, GetProductNutrientsResponse>> _getProductNutrientHandler;
        private readonly Mock<IHandler<GetProductsRequest, GetProductsResponse>> _getProductsHandler;

        public ProductsControllerTest()
        {
            _getProductHandler = new();
            _getProductsHandler = new();
            _getProductNutrientHandler = new();

            _controller = new(
                _getProductsHandler.Object,
                _getProductHandler.Object,
                _getProductNutrientHandler.Object
            );
        }

        [Fact(DisplayName = "If there are products, return them.")]
        public async void GetProducts_ReturnsProducts()
        {
            // Arrange
            GetProductsResponse response = new()
            {
                Products = new()
                {
                    new()
                    {
                        Code = 1
                    }
                }
            };
            _getProductsHandler.SetupHandle(_ => response);

            // Act
            var output = await _controller.GetProducts(new(), CancellationToken.None);

            // Assert
            Assert.IsType<OkObjectResult>(output.Result);
            var okObjectResult = output.Result as OkObjectResult;
            Verify.NotNull(okObjectResult);
            Verify.NotNull(okObjectResult.Value);
            Assert.Equal(response, okObjectResult.Value);
        }

        [Fact(DisplayName = "If no products exists, return not found.")]
        public async void GetProducts_ReturnsNotFound()
        {
            // Arrange
            _getProductsHandler.SetupHandle(_ => null);

            // Act
            var output = await _controller.GetProducts(new(), CancellationToken.None);

            // Assert
            Assert.IsType<NotFoundResult>(output.Result);
            Assert.Null(output.Value);
        }

        [Fact(DisplayName = "If the product exists, return it.")]
        public async void GetProduct_ReturnsProduct()
        {
            // Arrange
            GetProductResponse response = new()
            {
                Product = new()
                {
                    Code = 1
                }
            };
            _getProductHandler.SetupHandle(_ => response);

            // Act
            var output = await _controller.GetProduct(
                new()
                {
                    ProductCode = 1
                },
                CancellationToken.None);

            // Assert
            Assert.IsType<OkObjectResult>(output.Result);
            var okResult = output.Result as OkObjectResult;
            Verify.NotNull(okResult);
            Verify.NotNull(okResult.Value);
            Assert.Equal(response, okResult.Value);
        }

        [Fact(DisplayName = "If the product doesnt exists, return not found.")]
        public async void GetProduct_ReturnsNotFound()
        {
            // Arrange
            _getProductHandler.SetupHandle(_ => null);

            // Act
            var output = await _controller.GetProduct(
                new()
                {
                    ProductCode = 1
                }, CancellationToken.None);

            // Assert
            Assert.IsType<NotFoundResult>(output.Result);
            Assert.Null(output.Value);
        }

        [Fact(DisplayName = "If the products has nutrients, return it.")]
        public async void GetProductsNutrients_ReturnsProductNutrients()
        {
            // Arrange
            GetProductNutrientsResponse response = new()
            {
                Nutrients = new()
                {
                    new()
                    {
                        Percentage = 5,
                        NameEn = "En",
                        NameNl = "Nl"
                    }
                },
                Product = new()
                {
                    Code = 1
                }
            };

            _getProductNutrientHandler.SetupHandle(_ => response);

            // Act
            var output = await _controller.GetProductNutrients(
                new()
                {
                    ProductCode = 1
                },
                CancellationToken.None);

            // Assert
            Assert.IsType<OkObjectResult>(output.Result);
            var okResult = output.Result as OkObjectResult;
            Verify.NotNull(okResult);
            Verify.NotNull(okResult.Value);
            Assert.Equal(response, okResult.Value);
        }

        [Fact(DisplayName = "If no product nutrients exists, return not found.")]
        public async void GetProductNutrients_ReturnsNotFound()
        {
            // Arrange
            _getProductNutrientHandler.SetupHandle(_ => null);

            // Act
            var output = await _controller.GetProductNutrients(new()
            {
                ProductCode = 1
            }, CancellationToken.None);

            // Assert
            Assert.IsType<NotFoundResult>(output.Result);
            Assert.Null(output.Value);
        }
    }
}