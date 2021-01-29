using System.Threading;
using System.Threading.Tasks;
using Coded.Core.Handler;
using Coded.Core.Testing;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Nevo.Api.Controllers;
using Nevo.Contract.V1.Sources;
using Nevo.Test.Shared;
using Xunit;

namespace Nevo.Api.Test.Controllers
{
    public class SourcesControllerTest
    {
        private readonly Mock<IHandler<GetSourceRequest, GetSourceResponse>> _getSourceHandler;
        private readonly Mock<IHandler<GetSourceNutrientsRequest, GetSourceNutrientsResponse>> _getSourceNutrientsHandler;
        private readonly Mock<IHandler<GetSourcesRequest, GetSourcesResponse>> _getSourcesHandler;
        private readonly SourcesController _sourcesController;

        public SourcesControllerTest()
        {
            _getSourceHandler = new();
            _getSourcesHandler = new();
            _getSourceNutrientsHandler = new();
            _sourcesController = new(
                _getSourceHandler.Object,
                _getSourcesHandler.Object,
                _getSourceNutrientsHandler.Object);
        }

        [Fact(DisplayName = "If there are sources, return them.")]
        public async Task GetSourcesTest()
        {
            // Arrange
            GetSourcesResponse response = new()
            {
                Sources = new()
                {
                    new()
                    {
                        Id = "Id1",
                        SourceEn = "Source1En",
                        SourceNl = "Source1Nl"
                    },
                    new()
                    {
                        Id = "Id2",
                        SourceEn = "Source2En",
                        SourceNl = "Source2NL"
                    }
                }
            };

            _getSourcesHandler.SetupHandle(_ => response);

            // Act
            var output = await _sourcesController.GetSources(new(), CancellationToken.None);

            // Assert
            Assert.IsType<OkObjectResult>(output.Result);
            var okObjectResult = output.Result as OkObjectResult;
            Verify.NotNull(okObjectResult);
            Verify.NotNull(okObjectResult.Value);
            Assert.Equal(response, okObjectResult.Value);
        }

        [Fact(DisplayName = "If there are no sources, return not found.")]
        public async Task GetSources_NotFoundTest()
        {
            // Arrange
            _getSourcesHandler.SetupHandle(_ => null);

            // Act
            var output = await _sourcesController.GetSources(new(), CancellationToken.None);

            // Assert
            Assert.IsType<NotFoundResult>(output.Result);
            Assert.Null(output.Value);
        }

        [Fact(DisplayName = "If the source exists, return it.")]
        public async Task GetSourceTest()
        {
            // Arrange
            GetSourceResponse response = new()
            {
                Source = new()
                {
                    Id = "Id1",
                    SourceEn = "Source1En",
                    SourceNl = "Source1Nl"
                }
            };

            _getSourceHandler.SetupHandle(_ => response);

            // Act
            var output = await _sourcesController.GetSource(new()
            {
                SourceId = "Id1"
            }, CancellationToken.None);

            // Assert
            Assert.IsType<OkObjectResult>(output.Result);
            var okObjectResult = output.Result as OkObjectResult;
            Verify.NotNull(okObjectResult);
            Verify.NotNull(okObjectResult.Value);
            Assert.Equal(response, okObjectResult.Value);
        }

        [Fact(DisplayName = "If the sources doesn't exist, return not found.")]
        public async Task GetSource_NotFoundTest()
        {
            // Arrange
            _getSourceHandler.SetupHandle(_ => null);

            // Act
            var output = await _sourcesController.GetSource(new(), CancellationToken.None);

            // Assert
            Assert.IsType<NotFoundResult>(output.Result);
            Assert.Null(output.Value);
        }

        [Fact(DisplayName = "If the source nutrients exists, return it.")]
        public async Task GetSourceNutrientsTest()
        {
            // Arrange
            GetSourceNutrientsResponse response = new()
            {
                Nutrients = new()
                {
                    new()
                    {
                        NutrientCode = "NutrientCode",
                        Percentage = 5,
                        ProductCode = 1
                    }
                }
            };

            _getSourceNutrientsHandler.SetupHandle(_ => response);

            // Act
            var output = await _sourcesController.GetSourceNutrients(new()
            {
                SourceId = "Id1"
            }, CancellationToken.None);

            // Assert
            Assert.IsType<OkObjectResult>(output.Result);
            var okObjectResult = output.Result as OkObjectResult;
            Verify.NotNull(okObjectResult);
            Verify.NotNull(okObjectResult.Value);
            Assert.Equal(response, okObjectResult.Value);
        }

        [Fact(DisplayName = "If the source nutrient doesn't exist, return not found.")]
        public async Task GetSourceNutrient_NotFoundTest()
        {
            // Arrange
            _getSourceHandler.SetupHandle(_ => null);

            // Act
            var output = await _sourcesController.GetSourceNutrients(new(), CancellationToken.None);

            // Assert
            Assert.IsType<NotFoundResult>(output.Result);
            Assert.Null(output.Value);
        }
    }
}