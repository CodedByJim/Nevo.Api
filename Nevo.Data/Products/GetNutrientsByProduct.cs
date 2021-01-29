using Coded.Core.Query;

namespace Nevo.Data.Products
{
    /// <summary>
    ///     Get the nutrients by product.
    /// </summary>
    public sealed record GetNutrientsByProduct : IQueryArguments<EquatableList<ProductNutrient>>
    {
        /// <summary>
        ///     The product code.
        /// </summary>
        public int ProductCode { get; init; }

        /// <summary>
        ///     Implicit cast used to quickly wrap the product code.
        /// </summary>
        /// <param name="productCode">The product code.</param>
        /// <returns>A wrapped value.</returns>
        public static implicit operator GetNutrientsByProduct(int productCode) => new()
        {
            ProductCode = productCode
        };
    }
}