using System.Collections.Generic;
using Nevo.Data.Sources;

namespace Nevo.Contract.V1.Sources
{
    /// <summary>
    ///     Response to a get source nutrients request.
    /// </summary>
    public sealed record GetSourceNutrientsResponse : BasePaginatedResponse
    {
        /// <summary>
        ///     The nutrient values described in this source.
        /// </summary>
        public List<SourceNutrient>? Nutrients { get; init; }

        /// <summary>
        ///     The number of nutrients in this response.
        /// </summary>
        public override int Count => Nutrients?.Count ?? 0;
    }
}