using System.Collections.Generic;
using Moq;
using Nevo.Test.Shared;

namespace Nevo.Data.Test
{
    internal sealed class TestList : EquatableList<TestDataObject>
    {
        public TestList(IMock<IList<TestDataObject>>? innerList) : base(innerList?.Object!)
        {
        }
    }
}