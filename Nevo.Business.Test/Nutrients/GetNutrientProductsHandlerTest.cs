using System;
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
    public class GetNutrientProductsHandlerTest
    {
        private readonly Mock<IQuery<CountProductsByNutrient, Primitive<int>>> _countProductsByNutrientQuery;
        private readonly Mock<IQuery<GetProductsByNutrient, EquatableList<NutrientProduct>>> _getProductsByNutrientQuery;
        private readonly GetNutrientProductsHandler _handler;

        public GetNutrientProductsHandlerTest()
        {
            _getProductsByNutrientQuery = new();
            _countProductsByNutrientQuery = new();
            _handler = new(_getProductsByNutrientQuery.Object, _countProductsByNutrientQuery.Object);
        }

        [Fact(DisplayName = "Handle returns correct response.")]
        public async Task TestHandle()
        {
            // Arrange
            GetNutrientProductsRequest request = new()
            {
                NutrientCode = "1234"
            };

            List<NutrientProduct> nutrientProducts = new()
            {
                new()
                {
                    ProductCode = 1,
                    Percentage = 11,
                    SourceId = "SourceId1"
                },
                new()
                {
                    ProductCode = 2,
                    Percentage = 12,
                    SourceId = "SourceId2"
                }
            };

            _getProductsByNutrientQuery.SetupQuery(_ => nutrientProducts);
            _countProductsByNutrientQuery.SetupQuery(_ => 2);

            // Act
            var response = await _handler.Handle(request, CancellationToken.None);

            // Assert
            Verify.NotNull(response);
            Assert.Equal(2, response.Count);
            Assert.Equal(nutrientProducts, response.Products);
        }

        [Fact(DisplayName = "Handle returns null when no products exist.")]
        public async Task Handle_ReturnsNull_WhenNoNutrients()
        {
            // Arrange
            GetNutrientProductsRequest request = new()
            {
                NutrientCode = "15"
            };
            _getProductsByNutrientQuery.SetupQuery(_ => null);
            _countProductsByNutrientQuery.SetupQuery(_ => null);

            // Act
            var response = await _handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.Null(response);
        }

        [Fact(DisplayName = "Handle throws when nutrient code is null.")]
        public async Task Handle_Throws_WhenNutrientCodeNull()
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(
                () => _handler.Handle(new(), CancellationToken.None));
        }
    }
}