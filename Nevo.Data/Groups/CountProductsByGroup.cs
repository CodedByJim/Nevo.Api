using Coded.Core.Query;

namespace Nevo.Data.Groups
{
    /// <summary>
    ///     Count the products by group query arguments.
    /// </summary>
    public sealed record CountProductsByGroup : IQueryArguments<Primitive<int>>
    {
        /// <summary>
        ///     The group code.
        /// </summary>
        public int GroupCode { get; init; }

        /// <summary>
        ///     Implicit cast used to pass the group code as argument.
        /// </summary>
        /// <param name="groupCode">The group code.</param>
        /// <returns>Query arguments object.</returns>
        public static implicit operator CountProductsByGroup(int groupCode) => new()
        {
            GroupCode = groupCode
        };
    }
}