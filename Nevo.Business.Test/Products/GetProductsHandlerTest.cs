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
    public class GetProductsHandlerTest
    {
        private readonly Mock<IQuery<Count<Product>, Primitive<int>>> _countProductsQuery;
        private readonly Mock<IQuery<GetProducts, EquatableList<Product>>> _getProductsQuery;
        private readonly GetProductsHandler _handler;

        public GetProductsHandlerTest()
        {
            _getProductsQuery = new();
            _countProductsQuery = new();
            _handler = new(_getProductsQuery.Object, _countProductsQuery.Object);
        }

        [Fact(DisplayName = "Handle returns correct response.")]
        public async Task TestHandle()
        {
            // Arrange
            GetProductsRequest request = new()
            {
                Page = 1
            };
            _countProductsQuery.SetupQuery(_ => 100);
            EquatableList<Product> products = new()
            {
                new()
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
                    GroupCode = 54,
                    GroupDescriptionEn = "GroupDescriptionEn",
                    GroupDescriptionNl = "GroupDescriptionNl",
                    SynonymsEn = "SynonymsEn",
                    SynonymsNl = "SynonymsNl",
                    TraceAmounts = "TraceAmounts"
                },
                new()
                {
                    Code = 2,
                    CommentsEn = "CommentsEn2",
                    CommentsNl = "CommentsNl2",
                    DescriptionEn = "DescriptionEn2",
                    DescriptionNl = "DescriptionNl2",
                    EnergyKcal = 122,
                    EnergyKj = 132,
                    EnrichedWithEn = "EnrichedWithEn2",
                    EnrichedWithNl = "EnrichedWithNl2",
                    GroupCode = 542,
                    GroupDescriptionEn = "GroupDescriptionEn2",
                    GroupDescriptionNl = "GroupDescriptionNl2",
                    SynonymsEn = "SynonymsEn2",
                    SynonymsNl = "SynonymsNl2",
                    TraceAmounts = "TraceAmounts2"
                }
            };
            _getProductsQuery.SetupQuery(_ => products);

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            Verify.NotNull(result);
            Assert.Equal(100, result.Total);
            Assert.Equal(1, result.Page);
            Assert.Equal(2, result.Count);
            Assert.Equal(products, result.Products);
        }

        [Fact(DisplayName = "Handle returns null when no products exist.")]
        public async Task Handle_ReturnsNull_WhenNoNutrients()
        {
            // Act
            var response = await _handler.Handle(new(), CancellationToken.None);

            // Assert
            Assert.Null(response);
        }
    }
}