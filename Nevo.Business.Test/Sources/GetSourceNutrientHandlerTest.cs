using System.Threading;
using System.Threading.Tasks;
using Coded.Core.Query;
using Coded.Core.Testing;
using Moq;
using Nevo.Business.Sources;
using Nevo.Data;
using Nevo.Data.Sources;
using Nevo.Test.Shared;
using Xunit;

namespace Nevo.Business.Test.Sources
{
    public class GetSourceNutrientHandlerTest
    {
        private readonly Mock<IQuery<CountNutrientsBySource, Primitive<int>>> _countQuery;
        private readonly GetSourceNutrientsHandler _handler;
        private readonly Mock<IQuery<GetNutrientsBySource, EquatableList<SourceNutrient>>> _query;

        public GetSourceNutrientHandlerTest()
        {
            _countQuery = new();
            _query = new();
            _handler = new(_query.Object, _countQuery.Object);
        }

        [Fact(DisplayName = "Handle returns correct response.")]
        public async Task TestHandle()
        {
            // Arrange
            SourceNutrient[] sourceNutrients =
            {
                new()
                {
                    NutrientCode = "NutrientCode1",
                    Percentage = 50,
                    ProductCode = 1
                },
                new()
                {
                    NutrientCode = "NutrientCode2",
                    Percentage = 51,
                    ProductCode = 2
                }
            };
            _query.SetupQuery(_ => sourceNutrients);
            _countQuery.SetupQuery(_ => 2);

            // Act
            var result = await _handler.Handle(new()
            {
                Page = 1,
                SourceId = "Source1"
            }, CancellationToken.None);

            // Assert
            Verify.NotNull(result);
            Verify.NotNull(result.Nutrients);
            Assert.Equal(2, result.Nutrients.Count);

            Assert.Equal(2, result.Count);
            Assert.Equal(2, result.Total);
            Assert.Equal(1, result.TotalPages);
            Assert.False(result.HasNext);
            Assert.Equal("NutrientCode1", result.Nutrients[0].NutrientCode);
            Assert.Equal(50, result.Nutrients[0].Percentage);
            Assert.Equal(1, result.Nutrients[0].ProductCode);
            Assert.Equal("NutrientCode2", result.Nutrients[1].NutrientCode);
            Assert.Equal(51, result.Nutrients[1].Percentage);
            Assert.Equal(2, result.Nutrients[1].ProductCode);
        }

        [Fact(DisplayName = "Handle returns null when no sources exists.")]
        public async Task Handle_ReturnsNull_WhenNoSources()
        {
            // Act
            var response = await _handler.Handle(new(), CancellationToken.None);

            // Assert
            Assert.Null(response);
        }
    }
}