using System.Collections.Generic;
using Nevo.Data.Products;

namespace Nevo.Contract.V1.Products
{
    /// <summary>
    ///     The Product nutrients.
    /// </summary>
    public sealed record GetProductNutrientsResponse
    {
        /// <summary>
        ///     The product.
        /// </summary>
        public Product? Product { get; init; }

        /// <summary>
        ///     The nutrients in the product ordered by percentage.
        /// </summary>
        public List<ProductNutrient>? Nutrients { get; init; }

        /// <summary>
        ///     The number of nutrients returned.
        /// </summary>
        public int NutrientCount => Nutrients?.Count ?? 0;
    }
}