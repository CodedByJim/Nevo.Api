using System.Collections.Generic;
using Nevo.Data.Nutrients;

namespace Nevo.Contract.V1.Nutrients
{
    /// <summary>
    ///     Products containing a nutrient, ordered by percentage descending.
    /// </summary>
    public sealed record GetNutrientProductsResponse : BasePaginatedResponse
    {
        /// <summary>
        ///     The nutrient code.
        /// </summary>
        public string? NutrientCode { get; init; }

        /// <summary>
        ///     Products containing nutrient, ordered by percentage descending.
        /// </summary>
        public List<NutrientProduct>? Products { get; init; }

        /// <inheritdoc />
        public override int Count => Products?.Count ?? 0;
    }
}