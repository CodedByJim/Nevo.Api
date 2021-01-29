namespace Nevo.Data.Sources
{
    /// <summary>
    ///     Get nutrients by source query arguments.
    /// </summary>
    public sealed record GetNutrientsBySource : BasePaginatedQueryArguments<SourceNutrient>
    {
        /// <summary>
        ///     The product code.
        /// </summary>
        public string? SourceId { get; init; }
    }
}