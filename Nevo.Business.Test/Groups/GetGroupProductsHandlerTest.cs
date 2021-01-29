using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Coded.Core.Query;
using Coded.Core.Testing;
using Moq;
using Nevo.Business.Groups;
using Nevo.Contract.V1.Groups;
using Nevo.Data;
using Nevo.Data.Groups;
using Nevo.Test.Shared;
using Xunit;

namespace Nevo.Business.Test.Groups
{
    public class GetGroupProductsHandlerTest
    {
        private readonly Mock<IQuery<CountProductsByGroup, Primitive<int>>> _countProductsByGroup;
        private readonly Mock<IQuery<GetProductsByGroup, EquatableList<GroupProduct>>> _getProductsByGroup;
        private readonly GetGroupProductsHandler _handler;

        public GetGroupProductsHandlerTest()
        {
            _getProductsByGroup = new();
            _countProductsByGroup = new();
            _handler = new(_getProductsByGroup.Object, _countProductsByGroup.Object);
        }

        [Fact(DisplayName = "Handle returns correct response.")]
        public async Task TestHandle()
        {
            // Arrange
            GetGroupProductsRequest request = new();
            List<GroupProduct> products = new()
            {
                new()
                {
                    Code = 1,
                    DescriptionEn = "DescriptionEn1",
                    DescriptionNl = "DescriptionNl1"
                },
                new()
                {
                    Code = 2,
                    DescriptionEn = "DescriptionEn2",
                    DescriptionNl = "DescriptionNl2"
                }
            };
            _countProductsByGroup.SetupQuery(_ => 10);
            _getProductsByGroup.SetupQuery(_ => products);

            // Act
            var response = await _handler.Handle(request, CancellationToken.None);

            // Assert
            Verify.NotNull(response);
            Verify.NotNull(response.Products);
            Assert.Equal(products, response.Products);
            Assert.Equal(2, response.Count);

            Assert.Equal(1, response.Products[0].Code);
            Assert.Equal("DescriptionEn1", response.Products[0].DescriptionEn);
            Assert.Equal("DescriptionNl1", response.Products[0].DescriptionNl);

            Assert.Equal(2, response.Products[1].Code);
            Assert.Equal("DescriptionEn2", response.Products[1].DescriptionEn);
            Assert.Equal("DescriptionNl2", response.Products[1].DescriptionNl);
        }

        [Fact(DisplayName = "Handle returns null when there are no groups.")]
        public async Task Handle_ReturnsNull_WhenNoGroup()
        {
            // Arrange
            GetGroupProductsRequest request = new();

            _getProductsByGroup.SetupQuery(_ => null);

            // Act
            var response = await _handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.Null(response);
        }
    }
}