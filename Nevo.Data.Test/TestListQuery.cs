using Coded.Core.Data;
using Nevo.Test.Shared;

namespace Nevo.Data.Test
{
    public sealed class TestListQuery : ListQuery<TestQueryArguments, TestDataObject>
    {
        public TestListQuery(IUnitOfWork unitOfWork, string sql) : base(unitOfWork, sql)
        {
        }
    }
}