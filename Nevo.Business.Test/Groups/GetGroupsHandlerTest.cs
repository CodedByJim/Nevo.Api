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
    public class GetGroupsHandlerTest
    {
        private readonly Mock<IQuery<SelectAll<Group>, EquatableList<Group>>> _groupsQuery;
        private readonly GetGroupsHandler _handler;

        public GetGroupsHandlerTest()
        {
            _groupsQuery = new();
            _handler = new(_groupsQuery.Object);
        }

        [Fact(DisplayName = "Handle returns correct response.")]
        public async Task TestHandle()
        {
            // Arrange
            GetGroupsRequest request = new();
            List<Group> groups = new()
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

            _groupsQuery.SetupQuery(_ => groups);

            // Act
            var response = await _handler.Handle(request, CancellationToken.None);

            // Assert
            Verify.NotNull(response);
            Verify.NotNull(response.Groups);
            Assert.Equal(groups, response.Groups);
            Assert.Equal(2, response.Count);

            Assert.Equal(1, response.Groups[0].Code);
            Assert.Equal("DescriptionEn1", response.Groups[0].DescriptionEn);
            Assert.Equal("DescriptionNl1", response.Groups[0].DescriptionNl);

            Assert.Equal(2, response.Groups[1].Code);
            Assert.Equal("DescriptionEn2", response.Groups[1].DescriptionEn);
            Assert.Equal("DescriptionNl2", response.Groups[1].DescriptionNl);
        }

        [Fact(DisplayName = "Handle returns null when there are no groups.")]
        public async Task Handle_ReturnsNull_WhenNoGroup()
        {
            // Arrange
            GetGroupsRequest request = new();

            _groupsQuery.SetupQuery(_ => null);

            // Act
            var response = await _handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.Null(response);
        }
    }
}