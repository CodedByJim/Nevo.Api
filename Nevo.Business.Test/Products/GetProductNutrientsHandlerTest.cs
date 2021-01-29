using System.Threading;
using System.Threading.Tasks;
using Coded.Core.Query;
using Coded.Core.Testing;
using Moq;
using Nevo.Business.Products;
using Nevo.Contract.V1.Products;
using Nevo.Data;
using Nevo.Data.Products;
using Nevo.Test.Shared;
using Xunit;

namespace Nevo.Business.Test.Products
{
    public class GetProductNutrientsHandlerTest
    {
        private readonly Mock<IQuery<GetNutrientsByProduct, EquatableList<ProductNutrient>>> _getNutrientsByProductQuery;
        private readonly Mock<IQuery<SelectOne<Product, int>, Product>> _getProductQuery;
        private readonly GetProductNutrientsHandler _handler;

        public GetProductNutrientsHandlerTest()
        {
            _getNutrientsByProductQuery = new();
            _getProductQuery = new();
            _handler = new(_getNutrientsByProductQuery.Object, _getProductQuery.Object);
        }

        [Fact(DisplayName = "Handle returns correct response.")]
        public async Task TestHandle()
        {
            // Arrange
            GetProductNutrientsRequest request = new()
            {
                ProductCode = 1
            };

            Product product = new()
            {
                Code = 1,
                CommentsEn = "CommentsEn",
                CommentsNl = "CommentsNl",
                DescriptionEn = "DescriptionEn",
                DescriptionNl = "DescriptionNl",
                EnergyKcal = 12,
                EnergyKj = 13,
                EnrichedWithEn = "EnrichedWithEn",
                EnrichedWithNl = "EnrichedWithNl",
                GroupCode = 14,
                GroupDescriptionEn = "GroupDescriptionEn",
                GroupDescriptionNl = "GroupDescriptionNl",
                SynonymsEn = "SynonymsEn",
                SynonymsNl = "SynonymsNl",
                TraceAmounts = "TraceAmounts"
            };
            _getProductQuery.SetupQuery(_ => product);
            EquatableList<ProductNutrient> nutrients = new()
            {
                new()
                {
                    NameEn = "NameEn",
                    NameNl = "NameNl",
                    NutrientCode = "NutrientCode",
                    Percentage = 50,
                    SourceId = "SourceId"
                },
                new()
                {
                    NameEn = "NameEn1",
                    NameNl = "NameNl1",
                    NutrientCode = "NutrientCode1",
                    Percentage = 49,
                    SourceId = "SourceId1"
                }
            };
            _getNutrientsByProductQuery.SetupQuery(_ => nutrients);

            // Act
            var response = await _handler.Handle(request, CancellationToken.None);

            // Assert
            Verify.NotNull(response);
            Verify.NotNull(response.Product);
            Verify.NotNull(response.Nutrients);
            Assert.Equal(product, response.Product);
            Assert.Equal(nutrients, response.Nutrients);
            Assert.Equal(2, response.NutrientCount);
            Assert.Equal(2, response.Nutrients.Count);
        }

        [Fact(DisplayName = "Handle returns null when no nutrients exist.")]
        public async Task Handle_ReturnsNull_WhenNoNutrients()
        {
            // Arrange
            GetProductNutrientsRequest request = new();

            // Act
            var response = await _handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.Null(response);
        }
    }
}