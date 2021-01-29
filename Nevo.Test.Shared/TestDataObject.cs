using Nevo.Data;

namespace Nevo.Test.Shared
{
    public sealed record TestQueryArguments : BasePaginatedQueryArguments<TestDataObject>
    {
    }

    public record TestDataObject
    {
        public string? Id { get; init; }
    }
}