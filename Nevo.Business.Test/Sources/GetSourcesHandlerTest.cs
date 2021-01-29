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
    public class GetSourcesHandlerTest
    {
        private readonly Mock<IQuery<Count<Source>, Primitive<int>>> _countSourcesQuery;
        private readonly Mock<IQuery<GetSources, EquatableList<Source>>> _getSourcesQuery;
        private readonly GetSourcesHandler _handler;

        public GetSourcesHandlerTest()
        {
            _countSourcesQuery = new();
            _getSourcesQuery = new();
            _handler = new(_countSourcesQuery.Object, _getSourcesQuery.Object);
        }

        [Fact(DisplayName = "Handle returns correct response.")]
        public async Task TestHandle()
        {
            // Arrange
            var sources = new Source[]
            {
                new()
                {
                    Id = "Id",
                    SourceEn = "SourceEn",
                    SourceNl = "SourceNl"
                }
            };
            _getSourcesQuery.SetupQuery(_ => sources);
            _countSourcesQuery.SetupQuery(_ => 1);

            // Act
            var result = await _handler.Handle(new(), CancellationToken.None);

            // Assert
            Verify.NotNull(result);
            Verify.NotNull(result.Sources);
            Assert.Single(result.Sources);
            Assert.Equal(1, result.Count);
            Assert.Equal(1, result.Total);
            Assert.Equal(1, result.TotalPages);
            Assert.False(result.HasNext);
            Assert.Equal("Id", result.Sources[0].Id);
            Assert.Equal("SourceEn", result.Sources[0].SourceEn);
            Assert.Equal("SourceNl", result.Sources[0].SourceNl);
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