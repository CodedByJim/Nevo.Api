using Coded.Core.Query;

namespace Nevo.Data.Sources
{
    /// <summary>
    ///     Count nutrient values by source query arguments.
    /// </summary>
    public sealed record CountNutrientsBySource : IQueryArguments<Primitive<int>>
    {
        /// <summary>
        ///     The id of the source.
        /// </summary>
        public string? SourceId { get; init; }
    }
}