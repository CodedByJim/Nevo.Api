using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Coded.Core.Query;
using Coded.Core.Testing;
using Moq;
using Nevo.Business.Nutrients;
using Nevo.Contract.V1.Nutrients;
using Nevo.Data;
using Nevo.Data.Nutrients;
using Nevo.Test.Shared;
using Xunit;

namespace Nevo.Business.Test.Nutrients
{
    public class GetNutrientsHandlerTest
    {
        private readonly Mock<IQuery<SelectAll<Nutrient>, EquatableList<Nutrient>>> _getNutrientsQuery;
        private readonly GetNutrientsHandler _handler;

        public GetNutrientsHandlerTest()
        {
            _getNutrientsQuery = new();
            _handler = new(_getNutrientsQuery.Object);
        }

        [Fact(DisplayName = "Handle returns correct response.")]
        public async Task TestHandle()
        {
            // Arrange
            GetNutrientsRequest request = new();
            List<Nutrient> nutrientList = new()
            {
                new()
                {
                    Code = "Code1",
                    NameEn = "NameEn1",
                    NameNl = "NameNl1"
                },
                new()
                {
                    Code = "Code1",
                    NameEn = "NameEn1",
                    NameNl = "NameNl1"
                }
            };
            _getNutrientsQuery.SetupQuery(_ => nutrientList);

            // Act
            var response = await _handler.Handle(request, CancellationToken.None);

            // Assert
            Verify.NotNull(response);
            Assert.Equal(2, response.Count);
            Assert.Equal(nutrientList, response.Nutrients);
        }

        [Fact(DisplayName = "Handle returns null when no nutrients exist.")]
        public async Task Handle_ReturnsNull_WhenNoNutrients()
        {
            // Arrange
            GetNutrientsRequest request = new();
            _getNutrientsQuery.SetupQuery(_ => null);

            // Act
            var response = await _handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.Null(response);
        }
    }
}