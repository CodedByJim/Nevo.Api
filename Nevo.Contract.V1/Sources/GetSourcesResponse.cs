using System.Collections.Generic;
using Nevo.Data.Sources;

namespace Nevo.Contract.V1.Sources
{
    /// <summary>
    ///     The response to a get sources request.
    /// </summary>
    public sealed record GetSourcesResponse : BasePaginatedResponse
    {
        /// <summary>
        ///     The sources.
        /// </summary>
        public List<Source>? Sources { get; init; }

        /// <inheritdoc />
        public override int Count => Sources?.Count ?? 0;
    }
}