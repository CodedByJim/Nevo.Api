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
    public class GetGroupHandlerTest
    {
        private readonly Mock<IQuery<CountProductsByGroup, Primitive<int>>> _countProductsByGroupQuery;
        private readonly Mock<IQuery<SelectOne<Group, int>, Group>> _groupQuery;
        private readonly GetGroupHandler _handler;

        public GetGroupHandlerTest()
        {
            _countProductsByGroupQuery = new();
            _groupQuery = new();
            _handler = new(_countProductsByGroupQuery.Object, _groupQuery.Object);
        }

        [Fact(DisplayName = "Handle returns correct response.")]
        public async Task TestHandle()
        {
            // Arrange
            GetGroupRequest request = new()
            {
                GroupCode = 1234
            };
            _countProductsByGroupQuery.SetupQuery(_ => 100);
            _groupQuery.SetupQuery(args => new()
            {
                Code = args.Id,
                DescriptionEn = "DescriptionEn",
                DescriptionNl = "DescriptionNl"
            });

            // Act
            var response = await _handler.Handle(request, CancellationToken.None);

            // Assert
            Verify.NotNull(response);
            Verify.NotNull(response.Group);
            Assert.Equal(100, response.ProductCount);
            Assert.Equal(1234, response.Group.Code);
            Assert.Equal("DescriptionEn", response.Group.DescriptionEn);
            Assert.Equal("DescriptionNl", response.Group.DescriptionNl);
        }

        [Fact(DisplayName = "Handle returns null when group doesn't exist.")]
        public async Task Handle_ReturnsNull_WhenNoGroup()
        {
            // Arrange
            GetGroupRequest request = new()
            {
                GroupCode = 1234
            };

            _countProductsByGroupQuery.SetupQuery(_ => 0);
            _groupQuery.SetupQuery(_ => null);

            // Act
            var response = await _handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.Null(response);
        }
    }
}