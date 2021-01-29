using Nevo.Data.Sources;

namespace Nevo.Contract.V1.Sources
{
    /// <summary>
    ///     The response to a get source request.
    /// </summary>
    public sealed record GetSourceResponse
    {
        /// <summary>
        ///     The source found.
        /// </summary>
        public Source? Source { get; init; }
    }
}