using Coded.Core.Data;
using Nevo.Test.Shared;

namespace Nevo.Data.Test
{
    public sealed class TestSingleQuery : SingleQuery<SelectOne<TestDataObject, string>, TestDataObject>
    {
        public TestSingleQuery(IUnitOfWork unitOfWork, string sql) : base(unitOfWork, sql)
        {
        }
    }
}