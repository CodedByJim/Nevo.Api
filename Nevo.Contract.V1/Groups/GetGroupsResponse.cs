using System.Collections.Generic;
using Nevo.Data.Groups;

namespace Nevo.Contract.V1.Groups
{
    /// <summary>
    ///     Response to get groups request.
    /// </summary>
    public sealed record GetGroupsResponse
    {
        /// <summary>
        ///     List of groups.
        /// </summary>
        public List<Group>? Groups { get; init; }

        /// <summary>
        ///     Total number of groups in the response.
        /// </summary>
        public int Count => Groups?.Count ?? 0;
    }
}