using System;
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
    public class GetSourceHandlerTest
    {
        private readonly GetSourceHandler _handler;
        private readonly Mock<IQuery<SelectOne<Source, string>, Source>> _query;

        public GetSourceHandlerTest()
        {
            _query = new();
            _handler = new(_query.Object);
        }

        [Fact(DisplayName = "Handle returns correct response")]
        public async Task TestHandle()
        {
            // Arrange
            _query.SetupQuery(req => new()
            {
                Id = req.Id,
                SourceEn = "SourceEn",
                SourceNl = "SourceNl"
            });

            // Act
            var result = await _handler.Handle(new()
            {
                SourceId = "12345"
            }, CancellationToken.None);

            // Assert
            Verify.NotNull(result);
            Verify.NotNull(result.Source);
            Verify.NotNull(result.Source.Id);
            Verify.NotNull(result.Source.SourceEn);
            Verify.NotNull(result.Source.SourceNl);
            Assert.Equal("SourceNl", result.Source.SourceNl);
            Assert.Equal("SourceEn", result.Source.SourceEn);
        }

        [Fact(DisplayName = "Handle returns null when no source exists.")]
        public async Task Handle_ReturnsNull_WhenNoSource()
        {
            // Act
            var response = await _handler.Handle(new()
            {
                SourceId = "123"
            }, CancellationToken.None);

            // Assert
            Assert.Null(response);
        }

        [Fact(DisplayName = "Handle throws when source id is null.")]
        public async Task Handle_Throws_WhenSourceIdNull()
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _handler.Handle(new(), CancellationToken.None));
        }
    }
}