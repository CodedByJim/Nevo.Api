using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Coded.Core.Data;
using Dapper;
using Moq;
using Nevo.Test.Shared;
using Xunit;

namespace Nevo.Data.Test
{
    public class ListQueryTest
    {
        private const string SQL = "SELECT * FROM TestDataObject";
        private readonly ListQuery<TestQueryArguments, TestDataObject> _query;
        private readonly Mock<IUnitOfWork> _unitOfWork;

        public ListQueryTest()
        {
            _unitOfWork = new();
            _query = new TestListQuery(_unitOfWork.Object, SQL);
        }

        [Fact(DisplayName = "List query returns results.")]
        public async Task ListQuery_Query_ReturnsResults()
        {
            // Arrange
            var testData = new[]
            {
                new TestDataObject
                {
                    Id = "Id1"
                },
                new TestDataObject
                {
                    Id = "Id2"
                }
            };

            _unitOfWork.Setup(x => x.QueryAsync<TestDataObject>(SQL,
                    CancellationToken.None,
                    It.IsAny<object?>(),
                    It.IsAny<int?>(),
                    It.IsAny<CommandType?>(),
                    It.IsAny<CommandFlags>()))
                .ReturnsAsync(testData).Verifiable();

            // Act
            TestQueryArguments arguments = new()
            {
                Page = 1,
                Rows = 100
            };

            var result = await _query.Query(arguments, CancellationToken.None);

            // Assert
            _unitOfWork.Verify();
            Verify.NotNull(result);
            Assert.Equal(testData, result);
            Assert.Equal(100, arguments.Offset);
        }
    }
}