using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Moq;
using Nevo.Test.Shared;
using Xunit;

namespace Nevo.Data.Test
{
    public class EquatableListTest
    {
        private readonly TestList _equatableList;
        private readonly Mock<IList<TestDataObject>> _innerList;

        public EquatableListTest()
        {
            _innerList = new();
            _equatableList = new(_innerList);
        }

        [Fact(DisplayName = "Equatable list throws when initialized with a null inner list.")]
        public void TestInitialize()
        {
            Assert.Throws<ArgumentNullException>(() => new TestList(null!));
        }

        [Fact(DisplayName = "Equatable list compares count.")]
        public void TestCompareUnequal()
        {
            // Arrange
            EquatableList<string> list1 = new()
            {
                "1", "2", "3"
            };
            EquatableList<string> list2 = new()
            {
                "1", "2", "3", "4"
            };

            // Assert
            Assert.False(list1 == list2);
            list1.Add("5");
            Assert.False(list1 == list2);
            Assert.False(list1.Equals(null));
            Assert.False(list1 == null);
            Assert.False(null == list2);
        }

        [Fact(DisplayName = "Equatable list compares values.")]
        public void TestCompare()
        {
            // Arrange
            TestValue value1 = new()
            {
                Id = "test"
            };
            TestValue value2 = new()
            {
                Id = "test1".Substring(0, 4)
            };

            EquatableList<TestValue> list1 = new()
            {
                value1
            };

            EquatableList<TestValue> list2 = new()
            {
                value2
            };

            // Assert
            // ReSharper disable once PossibleUnintendedReferenceComparison
            Assert.False(value1 == value2);
            Assert.True(list1 == list2);
            Assert.False(list1 != list2);
            Assert.True(list1.GetHashCode() == list2.GetHashCode());
        }

        [Fact(DisplayName = "Equatable list decorates inner list.")]
        [SuppressMessage("ReSharper", "ReturnValueOfPureMethodIsNotUsed")]
        public void TestDecorator()
        {
            // Add
            TestDataObject item = new();
            _equatableList.Add(item);
            _innerList.Verify(x => x.Add(item));

            // Insert
            _equatableList.Insert(5656, item);
            _innerList.Verify(x => x.Insert(5656, item));

            // Indexer
            _innerList.SetupGet(x => x[0]).Returns(item);
            _equatableList[0] = item;
            var firstItem = _equatableList[0];
            _innerList.VerifyGet(x => x[0]);
            _innerList.VerifySet(x => x[0] = item);
            Assert.Equal(item, firstItem);

            // Count
            _innerList.SetupGet(x => x.Count).Returns(500);
            var count = _equatableList.Count;
            _innerList.Verify(x => x.Count);
            Assert.Equal(500, count);

            // IsReadOnly
            _innerList.SetupGet(x => x.IsReadOnly).Returns(true);
            var readOnly = _equatableList.IsReadOnly;
            _innerList.Verify(x => x.IsReadOnly);
            Assert.True(readOnly);

            // GetEnumerator
            _equatableList.GetEnumerator();
            _innerList.Verify(x => x.GetEnumerator());

            // GetEnumerator
            _equatableList.Clear();
            _innerList.Verify(x => x.Clear());

            // Contains
            _equatableList.Contains(item);
            _innerList.Verify(x => x.Contains(item));

            // IndexOf
            _equatableList.IndexOf(item);
            _innerList.Verify(x => x.IndexOf(item));

            // CopyTo
            var array = new TestDataObject[1];
            _equatableList.CopyTo(array, 50);
            _innerList.Verify(x => x.CopyTo(array, 50));

            // Remove
            _equatableList.Remove(item);
            _innerList.Verify(x => x.Remove(item));

            // RemoveAt
            _equatableList.RemoveAt(5126);
            _innerList.Verify(x => x.RemoveAt(5126));
        }
    }
}