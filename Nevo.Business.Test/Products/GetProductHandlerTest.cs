using System.Threading;
using System.Threading.Tasks;
using Coded.Core.Query;
using Coded.Core.Testing;
using Moq;
using Nevo.Business.Products;
using Nevo.Data;
using Nevo.Data.Products;
using Nevo.Test.Shared;
using Xunit;

namespace Nevo.Business.Test.Products
{
    public class GetProductHandlerTest
    {
        private readonly Mock<IQuery<SelectOne<Product, int>, Product>> _getProductQuery;
        private readonly GetProductHandler _handler;

        public GetProductHandlerTest()
        {
            _getProductQuery = new();
            _handler = new(_getProductQuery.Object);
        }

        [Fact(DisplayName = "Handle returns correct response.")]
        public async Task TestHandle()
        {
            // Arrange
            _getProductQuery.SetupQuery(args => new()
            {
                Code = args.Id,
                CommentsEn = "CommentsEn",
                CommentsNl = "CommentsNl",
                DescriptionEn = "DescriptionEn",
                DescriptionNl = "DescriptionNl"
            });

            // Act
            var result = await _handler.Handle(new()
            {
                ProductCode = 123456
            }, CancellationToken.None);

            // Assert
            Verify.NotNull(result);
            Verify.NotNull(result.Product);
            Assert.Equal(123456, result.Product.Code);
            Assert.Equal("CommentsEn", result.Product.CommentsEn);
            Assert.Equal("CommentsNl", result.Product.CommentsNl);
            Assert.Equal("DescriptionEn", result.Product.DescriptionEn);
            Assert.Equal("DescriptionNl", result.Product.DescriptionNl);
        }

        [Fact(DisplayName = "Handle returns null when no product exists.")]
        public async Task Handle_ReturnsNull_WhenNoProducts()
        {
            // Act
            var response = await _handler.Handle(new(), CancellationToken.None);

            // Assert
            Assert.Null(response);
        }
    }
}