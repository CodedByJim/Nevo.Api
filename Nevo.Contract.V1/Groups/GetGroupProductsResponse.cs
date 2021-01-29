using System.Collections.Generic;
using Nevo.Data.Groups;

namespace Nevo.Contract.V1.Groups
{
    /// <summary>
    ///     Response to get group product request.
    /// </summary>
    public sealed record GetGroupProductsResponse : BasePaginatedResponse
    {
        /// <summary>
        ///     Group code.
        /// </summary>
        public int GroupCode { get; init; }

        /// <summary>
        ///     Products within the group.
        /// </summary>
        public List<GroupProduct>? Products { get; init; }

        /// <inheritdoc />
        public override int Count => Products?.Count ?? 0;
    }
}