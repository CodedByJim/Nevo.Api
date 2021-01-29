using Nevo.Data.Groups;

namespace Nevo.Contract.V1.Groups
{
    /// <summary>
    ///     Response containing a single group.
    /// </summary>
    public sealed record GetGroupResponse
    {
        /// <summary>
        ///     A product group.
        /// </summary>
        public Group? Group { get; init; }

        /// <summary>
        ///     The number of products in this group.
        /// </summary>
        public int ProductCount { get; init; }
    }
}