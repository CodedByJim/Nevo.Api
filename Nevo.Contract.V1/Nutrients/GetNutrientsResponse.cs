using System.Collections.Generic;
using Nevo.Data.Nutrients;

namespace Nevo.Contract.V1.Nutrients
{
    /// <summary>
    ///     Returns the request nutrients.
    /// </summary>
    public sealed record GetNutrientsResponse
    {
        /// <summary>
        ///     List of all nutrients.
        /// </summary>
        public List<Nutrient>? Nutrients { get; init; }

        /// <summary>
        ///     Total number of Nutrients in the response.
        /// </summary>
        public int Count => Nutrients?.Count ?? 0;
    }
}