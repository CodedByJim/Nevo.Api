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
    public class SingleQueryTest
    {
        private const string SQL = "SELECT * FROM TestDataObject WHERE Id = @Id";
        private readonly SingleQuery<SelectOne<TestDataObject, string>, TestDataObject> _query;
        private readonly Mock<IUnitOfWork> _unitOfWork;

        public SingleQueryTest()
        {
            _unitOfWork = new();
            _query = new TestSingleQuery(_unitOfWork.Object, SQL);
        }

        [Fact(DisplayName = "List query returns results.")]
        public async Task SingleQuery_Query_ReturnsResults()
        {
            // Arrange
            var testData = new TestDataObject
            {
                Id = "Id1"
            };

            _unitOfWork.Setup(x => x.QuerySingleOrDefaultAsync<TestDataObject>(SQL,
                    CancellationToken.None,
                    It.IsAny<object?>(),
                    It.IsAny<int?>(),
                    It.IsAny<CommandType?>(),
                    It.IsAny<CommandFlags>()))
                .ReturnsAsync(testData).Verifiable();

            // Act
            var result = await _query.Query(new(), CancellationToken.None);

            // Assert
            _unitOfWork.Verify();
            Verify.NotNull(result);
            Assert.Equal(testData, result);
        }
    }
}