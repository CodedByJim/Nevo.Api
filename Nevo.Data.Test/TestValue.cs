using System;

namespace Nevo.Data.Test
{
    public class TestValue : IEquatable<TestValue>
    {
        public string? Id { get; init; }

        public bool Equals(TestValue? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id == other.Id;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((TestValue)obj);
        }

        public override int GetHashCode() => Id?.GetHashCode() ?? string.Empty.GetHashCode();
    }
}